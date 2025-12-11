using System;
using System.Drawing;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Gst;
using Gst.Video;
using Task = System.Threading.Tasks.Task;
using DateTime = System.DateTime;
using GValue = GLib.Value;

namespace GAMView.App;

public partial class MainForm : Form
{
    private const string DefaultPipelineTemplate =
        "udpsrc port={port} caps=\"application/x-rtp,media=video,encoding-name=H265,payload=96,clock-rate=90000\" " +
        "! rtpjitterbuffer name=jb latency=500 drop-on-latency=true " +
        "! rtph265depay name=depay ! h265parse name=parse ! avdec_h265 ! videoconvert ! d3dvideosink name=vsink sync=false";

    private const string BannerLogoFileName = "AM_whitenobg.png";
    private const string AppIconFileName = "logo_GAMview.ico";
    private const int DefaultClockPort = 5002;

    private Pipeline? _pipeline;
    private VideoOverlayAdapter? _overlay;
    private CancellationTokenSource? _busWatchCts;
    private readonly object _pipelineLock = new();

    private static readonly object GstInitLock = new();
    private static bool _gstInitialized;

    private string _pipelineTemplate = DefaultPipelineTemplate;
    private string _gstBasePath;
    private int _clockPort = DefaultClockPort;
    private CancellationTokenSource? _clockListenerCts;
    private Task? _clockListenerTask;
    private bool _clockListenerWarned;

    private readonly System.Windows.Forms.Timer _statsTimer;
    private DateTime _lastStatsSampleUtc = DateTime.UtcNow;
    private long _bytesSinceLast;
    private long _framesSinceLast;
    private long _lastPacketTicks;
    private double _lastBitrateMbps;
    private double _lastFps;
    private double _lastLatencyMs;
    private double _lastClockLatencyMs;
    private long _lastClockSampleTicks;
    private double _lastLossPercent;
    private double _lastPacketAgoSeconds;

    private Pad? _statsPad;
    private ulong _statsProbeId;

    public MainForm()
    {
        InitializeComponent();

        _gstBasePath = Program.DefaultGstBasePath;
        pipelineTextBox.Text = _pipelineTemplate;
        gstPathTextBox.Text = _gstBasePath;
        clockPortTextBox.Text = _clockPort.ToString();

        _statsTimer = new System.Windows.Forms.Timer { Interval = 1000 };
        _statsTimer.Tick += StatsTimerOnTick;

        SetUiState(false);
        UpdateStatus("Arrêté");
        UpdateStatsLabels();
        LoadBranding();
    }

    private void StartButton_Click(object? sender, EventArgs e)
    {
        StartStream();
    }

    private void StopButton_Click(object? sender, EventArgs e)
    {
        StopStream();
    }

    private void ApplyOptionsButton_Click(object? sender, EventArgs e)
    {
        _pipelineTemplate = string.IsNullOrWhiteSpace(pipelineTextBox.Text)
            ? DefaultPipelineTemplate
            : pipelineTextBox.Text.Trim();

        _gstBasePath = gstPathTextBox.Text.Trim();
        Program.ConfigureGStreamerEnvironment(_gstBasePath);

        if (!TryReadClockPort(out var clockPort, false))
        {
            MessageBox.Show(this, "Port horloge invalide (0-65535).", "Paramètres", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        _clockPort = clockPort;
        if (_pipeline != null)
        {
            StartClockListener(clockPort);
        }

        MessageBox.Show(this, "Options mises à jour. Relancez le flux pour appliquer.", "Options",
            MessageBoxButtons.OK, MessageBoxIcon.Information);
    }

    private void ResetPipelineButton_Click(object? sender, EventArgs e)
    {
        _pipelineTemplate = DefaultPipelineTemplate;
        pipelineTextBox.Text = DefaultPipelineTemplate;
    }

    private void MainForm_FormClosing(object? sender, FormClosingEventArgs e)
    {
        StopStream();
    }

    private void StartStream()
    {
        if (!int.TryParse(portTextBox.Text, out var port) || port <= 0 || port > 65535)
        {
            MessageBox.Show(this, "Port UDP invalide (0-65535).", "Paramètres", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        if (!TryReadClockPort(out var clockPort, true))
        {
            return;
        }

        _clockPort = clockPort;

        lock (_pipelineLock)
        {
            StopStreamInternal();

            try
            {
                Program.ConfigureGStreamerEnvironment(_gstBasePath);
                EnsureGstInitialized();

                var pipelineString = BuildPipelineString(port);
                _pipeline = (Pipeline)Parse.Launch(pipelineString);

                var videoSink = _pipeline.GetByName("vsink");
                if (videoSink == null)
                {
                    throw new InvalidOperationException("Impossible de récupérer le sink vidéo (vsink).");
                }

                _overlay = new VideoOverlayAdapter(videoSink.Handle)
                {
                    WindowHandle = videoPanel.Handle
                };
                _overlay.HandleEvents(true);
                _overlay.PrepareWindowHandle();

                AttachStatsProbe();

                var bus = _pipeline.Bus;
                bus.EnableSyncMessageEmission();
                bus.SyncMessage += BusOnSyncMessage;

                _busWatchCts = new CancellationTokenSource();
                Task.Run(() => WatchBus(bus, _busWatchCts.Token));

                _pipeline.SetState(State.Playing);
                StartClockListener(clockPort);

                _lastStatsSampleUtc = DateTime.UtcNow;
                _bytesSinceLast = 0;
                _framesSinceLast = 0;
                _lastPacketTicks = 0;
                _lastPacketAgoSeconds = 0;
                _statsTimer.Start();

                UpdateStatus("Lecture en cours");
                SetUiState(true);
            }
            catch (Exception ex)
            {
                UpdateStatus("Erreur");
                SetUiState(false);
                MessageBox.Show(this, $"Impossible de démarrer le flux.\n{ex.Message}", "Erreur GStreamer", MessageBoxButtons.OK, MessageBoxIcon.Error);
                StopStreamInternal();
            }
        }
    }

    private void StopStream()
    {
        lock (_pipelineLock)
        {
            StopStreamInternal();
        }

        UpdateStatus("Arrêté");
        SetUiState(false);
        ResetStats();
    }

    private void StopStreamInternal()
    {
        _statsTimer.Stop();
        StopClockListener();

        if (_statsPad != null && _statsProbeId != 0)
        {
            try
            {
                _statsPad.RemoveProbe(_statsProbeId);
            }
            catch
            {
                // ignore cleanup failure
            }

            _statsPad = null;
            _statsProbeId = 0;
        }

        _busWatchCts?.Cancel();
        _busWatchCts = null;

        if (_pipeline != null)
        {
            try
            {
                _pipeline.SetState(State.Null);
            }
            catch
            {
                // Best effort teardown
            }

            try
            {
                _pipeline.Bus.SyncMessage -= BusOnSyncMessage;
            }
            catch
            {
                // Bus may already be gone
            }

            _pipeline.Dispose();
            _pipeline = null;
        }

        _overlay = null;
    }

    private string BuildPipelineString(int port)
    {
        return _pipelineTemplate.Replace("{port}", port.ToString());
    }

    private bool TryReadClockPort(out int clockPort, bool showWarning)
    {
        if (int.TryParse(clockPortTextBox.Text, out var parsed) && parsed > 0 && parsed <= 65535)
        {
            clockPort = parsed;
            return true;
        }

        clockPort = _clockPort;
        if (showWarning)
        {
            MessageBox.Show(this, "Port horloge invalide (0-65535).", "Paramètres", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        return false;
    }

    private void StartClockListener(int clockPort)
    {
        if (clockPort <= 0 || clockPort > 65535)
        {
            return;
        }

        StopClockListener();

        _clockListenerCts = new CancellationTokenSource();
        _clockListenerWarned = false;
        _clockListenerTask = Task.Run(() => RunClockListener(clockPort, _clockListenerCts.Token));
    }

    private async Task RunClockListener(int clockPort, CancellationToken token)
    {
        try
        {
            using var client = CreateClockUdpClient(clockPort);
            while (!token.IsCancellationRequested)
            {
                UdpReceiveResult result;
                try
                {
                    result = await client.ReceiveAsync(token).ConfigureAwait(false);
                }
                catch (OperationCanceledException)
                {
                    break;
                }
                catch (ObjectDisposedException)
                {
                    break;
                }

                var payload = Encoding.UTF8.GetString(result.Buffer).Trim();
                if (TryParseRemoteTimestamp(payload, out var remoteTimestampNs))
                {
                    UpdateLatencyFromClock(remoteTimestampNs);
                }
            }
        }
        catch (Exception ex)
        {
            if (!_clockListenerWarned)
            {
                _clockListenerWarned = true;
                BeginInvoke(new Action(() =>
                    MessageBox.Show(this,
                        $"Impossible d'écouter le port horloge UDP {clockPort}.\n{ex.Message}",
                        "Port horloge",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning)));
            }
        }
    }

    private static UdpClient CreateClockUdpClient(int clockPort)
    {
        // Allow coexistence with external listeners when possible
        var socket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp)
        {
            ExclusiveAddressUse = false
        };
        socket.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.ReuseAddress, true);
        socket.Bind(new System.Net.IPEndPoint(System.Net.IPAddress.Any, clockPort));
        return new UdpClient { Client = socket };
    }

    private static bool TryParseRemoteTimestamp(string payload, out long timestampNs)
    {
        // Accept pure integer or a value suffixed with "ns"
        if (long.TryParse(payload, out timestampNs))
        {
            return true;
        }

        const string suffix = "ns";
        if (payload.EndsWith(suffix, StringComparison.OrdinalIgnoreCase))
        {
            var trimmed = payload[..^suffix.Length].Trim();
            if (long.TryParse(trimmed, out timestampNs))
            {
                return true;
            }
        }

        timestampNs = 0;
        return false;
    }

    private void StopClockListener()
    {
        try
        {
            _clockListenerCts?.Cancel();
        }
        catch
        {
            // ignored
        }

        try
        {
            _clockListenerTask?.Wait(200);
        }
        catch
        {
            // ignored
        }

        _clockListenerTask = null;
        _clockListenerCts?.Dispose();
        _clockListenerCts = null;
    }

    private void UpdateLatencyFromClock(long remoteTimestampNs)
    {
        // Convert to Unix epoch nanoseconds to match sender
        var nowNs = (DateTime.UtcNow - DateTime.UnixEpoch).Ticks * 100L;
        var deltaNs = Math.Abs(nowNs - remoteTimestampNs);
        var latencyMs = deltaNs / 1_000_000.0;

        _lastClockLatencyMs = latencyMs;
        Interlocked.Exchange(ref _lastClockSampleTicks, DateTime.UtcNow.Ticks);
        _lastLatencyMs = latencyMs;
    }

    private bool HasRecentClockSample(DateTime utcNow)
    {
        var ticks = Interlocked.Read(ref _lastClockSampleTicks);
        if (ticks <= 0)
        {
            return false;
        }

        var last = new DateTime(ticks, DateTimeKind.Utc);
        return (utcNow - last).TotalSeconds < 5;
    }

    private void ApplyLatencyValue(double? latencyMs, DateTime utcNow)
    {
        if (HasRecentClockSample(utcNow))
        {
            _lastLatencyMs = _lastClockLatencyMs;
        }
        else if (latencyMs.HasValue)
        {
            _lastLatencyMs = latencyMs.Value;
        }
    }

    private void WatchBus(Bus bus, CancellationToken token)
    {
        while (!token.IsCancellationRequested)
        {
            Gst.Message? msg;
            try
            {
                msg = bus.TimedPopFiltered(100_000_000, MessageType.Error | MessageType.Eos | MessageType.Qos);
            }
            catch
            {
                return;
            }

            if (msg == null)
            {
                continue;
            }

            try
            {
                switch (msg.Type)
                {
                    case MessageType.Error:
                        msg.ParseError(out var gex, out var debug);
                        var message = gex?.Message ?? "Erreur inconnue";
                        BeginInvoke(new Action(() => HandlePipelineError(message, debug)));
                        return;
                    case MessageType.Eos:
                        BeginInvoke(new Action(HandlePipelineEos));
                        return;
                    case MessageType.Qos:
                        msg.ParseQos(out _, out _, out _, out var timestamp, out var duration);
                        UpdateLatencyFromQos(timestamp, duration);
                        break;
                }
            }
            finally
            {
                msg.Dispose();
            }
        }
    }

    private void HandlePipelineError(string message, string? debug)
    {
        UpdateStatus("Erreur");
        SetUiState(false);
        var details = string.IsNullOrWhiteSpace(debug) ? message : $"{message}\n\n{debug}";
        MessageBox.Show(this, details, "Erreur GStreamer", MessageBoxButtons.OK, MessageBoxIcon.Error);
        StopStream();
    }

    private void HandlePipelineEos()
    {
        UpdateStatus("Fin du flux");
        SetUiState(false);
        StopStream();
    }

    private void BusOnSyncMessage(object? sender, SyncMessageArgs args)
    {
        if (_overlay == null)
        {
            return;
        }

        if (args.Message.Type == MessageType.Element &&
            args.Message.Structure != null &&
            args.Message.Structure.Name == "prepare-window-handle")
        {
            _overlay.WindowHandle = videoPanel.Handle;
            _overlay.HandleEvents(true);
        }
    }

    private void AttachStatsProbe()
    {
        _statsPad = null;
        _statsProbeId = 0;

        if (_pipeline == null)
        {
            return;
        }

        foreach (var elementName in new[] { "parse", "depay", "jb" })
        {
            if (_pipeline.GetByName(elementName) is not Element element)
            {
                continue;
            }

            var pad = element.GetStaticPad("src") ?? element.GetStaticPad("sink");
            if (pad == null)
            {
                continue;
            }

            _statsPad = pad;
            _statsProbeId = pad.AddProbe(PadProbeType.Buffer, StatsProbe);
            break;
        }
    }

    private PadProbeReturn StatsProbe(Pad pad, PadProbeInfo info)
    {
        if (info.Buffer != null)
        {
            info.Buffer.GetSizes(out _, out var size);
            Interlocked.Add(ref _bytesSinceLast, (long)size);
            Interlocked.Increment(ref _framesSinceLast);
            Interlocked.Exchange(ref _lastPacketTicks, DateTime.UtcNow.Ticks);
        }

        return PadProbeReturn.Ok;
    }

    private void StatsTimerOnTick(object? sender, EventArgs e)
    {
        if (_pipeline == null)
        {
            ResetStats();
            return;
        }

        var now = DateTime.UtcNow;
        var elapsed = now - _lastStatsSampleUtc;
        if (elapsed.TotalSeconds <= 0.05)
        {
            return;
        }

        var bytes = Interlocked.Exchange(ref _bytesSinceLast, 0);
        var frames = Interlocked.Exchange(ref _framesSinceLast, 0);

        _lastBitrateMbps = bytes > 0
            ? (bytes * 8.0 / 1_000_000.0) / elapsed.TotalSeconds
            : 0.0;

        _lastFps = frames > 0
            ? frames / elapsed.TotalSeconds
            : 0.0;

        UpdateLatencyAndLoss();

        var lastTicks = Interlocked.Read(ref _lastPacketTicks);
        if (lastTicks > 0)
        {
            var last = new DateTime(lastTicks, DateTimeKind.Utc);
            var delta = now - last;
            _lastPacketAgoSeconds = Math.Max(0, delta.TotalSeconds);
        }
        else
        {
            _lastPacketAgoSeconds = 0;
        }

        UpdateStatsLabels();

        _lastStatsSampleUtc = now;
    }

    private void UpdateLatencyAndLoss()
    {
        var pipeline = _pipeline;
        if (pipeline == null)
        {
            return;
        }

        double? latencyMs = null;
        double? lossPercent = null;

        if (pipeline.GetByName("jb") is Element jitter)
        {
            if (TryGetStructureProperty(jitter, "stats", out var stats) && stats != null)
            {
                var pushed = GetLong(stats, "num-pushed");
                var lost = GetLong(stats, "num-lost");
                var total = pushed + lost;
                if (total > 0)
                {
                    lossPercent = Math.Max(0, Math.Min(100, lost * 100.0 / total));
                }

                var jitterNs = GetLong(stats, "avg-jitter");
                if (jitterNs > 0)
                {
                    latencyMs = jitterNs / 1_000_000.0;
                }
            }
        }

        ApplyLatencyValue(latencyMs, DateTime.UtcNow);

        if (lossPercent.HasValue)
        {
            _lastLossPercent = lossPercent.Value;
        }
    }

    private void UpdateLatencyFromQos(ulong timestamp, ulong duration)
    {
        var now = DateTime.UtcNow;
        if (HasRecentClockSample(now))
        {
            return;
        }

        if (duration > 0)
        {
            ApplyLatencyValue(duration / 1_000_000.0, now);
        }
        else if (timestamp > 0)
        {
            ApplyLatencyValue(timestamp / 1_000_000.0, now);
        }
    }

    private static bool TryGetStructureProperty(Element element, string propertyName, out Structure? structure)
    {
        try
        {
            var val = element[propertyName];
            if (val is GValue gValue && gValue.Val is Structure s)
            {
                structure = s;
                return true;
            }

            structure = null;
            return false;
        }
        catch
        {
            structure = null;
            return false;
        }
    }

    private static long GetLong(Structure structure, string field)
    {
        try
        {
            var val = structure.GetValue(field);
            return Convert.ToInt64(val.Val);
        }
        catch
        {
            return 0;
        }
    }

    private void UpdateStatus(string text)
    {
        if (InvokeRequired)
        {
            BeginInvoke(new Action(() => UpdateStatus(text)));
            return;
        }

        headerStatusValueLabel.Text = text;
        headerStatusValueLabel.ForeColor = text.StartsWith("Lecture", StringComparison.OrdinalIgnoreCase)
            ? Color.LimeGreen
            : Color.White;
    }

    private void SetUiState(bool isPlaying)
    {
        startButton.Enabled = !isPlaying;
        stopButton.Enabled = isPlaying;
        portTextBox.Enabled = !isPlaying;
    }

    private void ResetStats()
    {
        _bytesSinceLast = 0;
        _framesSinceLast = 0;
        _lastPacketTicks = 0;
        _lastBitrateMbps = 0;
        _lastFps = 0;
        _lastClockLatencyMs = 0;
        _lastClockSampleTicks = 0;
        _lastLatencyMs = 0;
        _lastLossPercent = 0;
        _lastPacketAgoSeconds = 0;
        UpdateStatsLabels();
    }

    private void UpdateStatsLabels()
    {
        bitrateValueLabel.Text = _lastBitrateMbps > 0 ? $"{_lastBitrateMbps:F2} Mbit/s" : "-";
        fpsValueLabel.Text = _lastFps > 0 ? $"{_lastFps:F1} fps" : "-";
        latencyValueLabel.Text = _lastLatencyMs > 0 ? $"{_lastLatencyMs:F1} ms" : "-";
        lossValueLabel.Text = _lastLossPercent > 0 ? $"{_lastLossPercent:F2} %" : "-";
        lastPacketValueLabel.Text = _lastPacketAgoSeconds > 0
            ? $"{_lastPacketAgoSeconds:F1} s"
            : "-";
    }

    private static void EnsureGstInitialized()
    {
        if (_gstInitialized)
        {
            return;
        }

        lock (GstInitLock)
        {
            if (_gstInitialized)
            {
                return;
            }

            Gst.Application.Init();
            _gstInitialized = true;
        }
    }

    private void LoadBranding()
    {
        try
        {
            var baseDir = AppContext.BaseDirectory;
            var logoPath = Path.Combine(baseDir, BannerLogoFileName);
            if (File.Exists(logoPath))
            {
                using var img = Image.FromFile(logoPath);
                headerLogoPictureBox.Image = new Bitmap(img);
            }

            var iconPath = Path.Combine(baseDir, AppIconFileName);
            if (File.Exists(iconPath))
            {
                Icon = new Icon(iconPath);
            }
        }
        catch
        {
            // Non blocking if assets are missing
        }
    }
}
