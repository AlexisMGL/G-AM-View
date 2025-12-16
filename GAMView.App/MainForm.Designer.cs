namespace GAMView.App;

partial class MainForm
{
    private System.ComponentModel.IContainer components = null;

    private System.Windows.Forms.Panel headerPanel;
    private System.Windows.Forms.PictureBox headerLogoPictureBox;
    private System.Windows.Forms.Label headerTitleLabel;
    private System.Windows.Forms.Label headerSubtitleLabel;
    private System.Windows.Forms.Label headerStatusLabel;
    private System.Windows.Forms.Label headerStatusValueLabel;

    private System.Windows.Forms.TabControl mainTabs;
    private System.Windows.Forms.TabPage playbackTab;
    private System.Windows.Forms.TabPage optionsTab;

    private System.Windows.Forms.Panel playbackControlsPanel;
    private System.Windows.Forms.FlowLayoutPanel controlFlowPanel;
    private System.Windows.Forms.Label portLabel;
    private System.Windows.Forms.TextBox portTextBox;
    private System.Windows.Forms.Button startButton;
    private System.Windows.Forms.Button stopButton;
    private System.Windows.Forms.FlowLayoutPanel audioControlFlowPanel;
    private System.Windows.Forms.Label audioPortLabel;
    private System.Windows.Forms.TextBox audioPortTextBox;
    private System.Windows.Forms.Button audioStartButton;
    private System.Windows.Forms.Button audioStopButton;
    private System.Windows.Forms.Label audioVolumeLabel;
    private System.Windows.Forms.TrackBar audioVolumeTrackBar;
    private System.Windows.Forms.Label audioVolumeValueLabel;
    private System.Windows.Forms.Label audioStatusLabel;
    private System.Windows.Forms.Label audioStatusValueLabel;

    private System.Windows.Forms.FlowLayoutPanel statsFlowPanel;
    private System.Windows.Forms.Label bitrateLabel;
    private System.Windows.Forms.Label bitrateValueLabel;
    private System.Windows.Forms.Label fpsLabel;
    private System.Windows.Forms.Label fpsValueLabel;
    private System.Windows.Forms.Label latencyLabel;
    private System.Windows.Forms.Label latencyValueLabel;
    private System.Windows.Forms.Label lossLabel;
    private System.Windows.Forms.Label lossValueLabel;
    private System.Windows.Forms.Label lastPacketLabel;
    private System.Windows.Forms.Label lastPacketValueLabel;

    private System.Windows.Forms.Panel videoPanel;

    private System.Windows.Forms.Label pipelineLabel;
    private System.Windows.Forms.TextBox pipelineTextBox;
    private System.Windows.Forms.Label pipelineHintLabel;
    private System.Windows.Forms.Button resetPipelineButton;
    private System.Windows.Forms.Label audioPipelineLabel;
    private System.Windows.Forms.TextBox audioPipelineTextBox;
    private System.Windows.Forms.Label audioPipelineHintLabel;
    private System.Windows.Forms.Button resetAudioPipelineButton;
    private System.Windows.Forms.Label clockPortLabel;
    private System.Windows.Forms.TextBox clockPortTextBox;
    private System.Windows.Forms.Label gstPathLabel;
    private System.Windows.Forms.TextBox gstPathTextBox;
    private System.Windows.Forms.Button applyOptionsButton;
    private System.Windows.Forms.Label optionsInfoLabel;

    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null))
        {
            components.Dispose();
        }
        base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    private void InitializeComponent()
    {
        this.components = new System.ComponentModel.Container();
        this.headerPanel = new System.Windows.Forms.Panel();
        this.headerStatusValueLabel = new System.Windows.Forms.Label();
        this.headerStatusLabel = new System.Windows.Forms.Label();
        this.headerSubtitleLabel = new System.Windows.Forms.Label();
        this.headerTitleLabel = new System.Windows.Forms.Label();
        this.headerLogoPictureBox = new System.Windows.Forms.PictureBox();
        this.mainTabs = new System.Windows.Forms.TabControl();
        this.playbackTab = new System.Windows.Forms.TabPage();
        this.videoPanel = new System.Windows.Forms.Panel();
        this.playbackControlsPanel = new System.Windows.Forms.Panel();
        this.audioControlFlowPanel = new System.Windows.Forms.FlowLayoutPanel();
        this.audioPortLabel = new System.Windows.Forms.Label();
        this.audioPortTextBox = new System.Windows.Forms.TextBox();
        this.audioStartButton = new System.Windows.Forms.Button();
        this.audioStopButton = new System.Windows.Forms.Button();
        this.audioVolumeLabel = new System.Windows.Forms.Label();
        this.audioVolumeTrackBar = new System.Windows.Forms.TrackBar();
        this.audioVolumeValueLabel = new System.Windows.Forms.Label();
        this.audioStatusLabel = new System.Windows.Forms.Label();
        this.audioStatusValueLabel = new System.Windows.Forms.Label();
        this.statsFlowPanel = new System.Windows.Forms.FlowLayoutPanel();
        this.bitrateLabel = new System.Windows.Forms.Label();
        this.bitrateValueLabel = new System.Windows.Forms.Label();
        this.fpsLabel = new System.Windows.Forms.Label();
        this.fpsValueLabel = new System.Windows.Forms.Label();
        this.latencyLabel = new System.Windows.Forms.Label();
        this.latencyValueLabel = new System.Windows.Forms.Label();
        this.lossLabel = new System.Windows.Forms.Label();
        this.lossValueLabel = new System.Windows.Forms.Label();
        this.lastPacketLabel = new System.Windows.Forms.Label();
        this.lastPacketValueLabel = new System.Windows.Forms.Label();
        this.controlFlowPanel = new System.Windows.Forms.FlowLayoutPanel();
        this.portLabel = new System.Windows.Forms.Label();
        this.portTextBox = new System.Windows.Forms.TextBox();
        this.startButton = new System.Windows.Forms.Button();
        this.stopButton = new System.Windows.Forms.Button();
        this.optionsTab = new System.Windows.Forms.TabPage();
        this.optionsInfoLabel = new System.Windows.Forms.Label();
        this.applyOptionsButton = new System.Windows.Forms.Button();
        this.gstPathTextBox = new System.Windows.Forms.TextBox();
        this.gstPathLabel = new System.Windows.Forms.Label();
        this.clockPortTextBox = new System.Windows.Forms.TextBox();
        this.clockPortLabel = new System.Windows.Forms.Label();
        this.resetAudioPipelineButton = new System.Windows.Forms.Button();
        this.resetPipelineButton = new System.Windows.Forms.Button();
        this.audioPipelineHintLabel = new System.Windows.Forms.Label();
        this.pipelineHintLabel = new System.Windows.Forms.Label();
        this.audioPipelineTextBox = new System.Windows.Forms.TextBox();
        this.pipelineTextBox = new System.Windows.Forms.TextBox();
        this.audioPipelineLabel = new System.Windows.Forms.Label();
        this.pipelineLabel = new System.Windows.Forms.Label();
        ((System.ComponentModel.ISupportInitialize)(this.audioVolumeTrackBar)).BeginInit();
        this.headerPanel.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)(this.headerLogoPictureBox)).BeginInit();
        this.mainTabs.SuspendLayout();
        this.playbackTab.SuspendLayout();
        this.playbackControlsPanel.SuspendLayout();
        this.audioControlFlowPanel.SuspendLayout();
        this.statsFlowPanel.SuspendLayout();
        this.controlFlowPanel.SuspendLayout();
        this.optionsTab.SuspendLayout();
        this.SuspendLayout();
        // 
        // headerPanel
        // 
        this.headerPanel.BackColor = System.Drawing.Color.Black;
        this.headerPanel.Controls.Add(this.headerStatusValueLabel);
        this.headerPanel.Controls.Add(this.headerStatusLabel);
        this.headerPanel.Controls.Add(this.headerSubtitleLabel);
        this.headerPanel.Controls.Add(this.headerTitleLabel);
        this.headerPanel.Controls.Add(this.headerLogoPictureBox);
        this.headerPanel.Dock = System.Windows.Forms.DockStyle.Top;
        this.headerPanel.Location = new System.Drawing.Point(0, 0);
        this.headerPanel.Name = "headerPanel";
        this.headerPanel.Padding = new System.Windows.Forms.Padding(12, 10, 12, 10);
        this.headerPanel.Size = new System.Drawing.Size(1184, 96);
        this.headerPanel.TabIndex = 0;
        // 
        // headerStatusValueLabel
        // 
        this.headerStatusValueLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
        this.headerStatusValueLabel.AutoSize = true;
        this.headerStatusValueLabel.Font = new System.Drawing.Font("Segoe UI Semibold", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
        this.headerStatusValueLabel.ForeColor = System.Drawing.Color.White;
        this.headerStatusValueLabel.Location = new System.Drawing.Point(1081, 17);
        this.headerStatusValueLabel.Name = "headerStatusValueLabel";
        this.headerStatusValueLabel.Size = new System.Drawing.Size(57, 20);
        this.headerStatusValueLabel.TabIndex = 4;
        this.headerStatusValueLabel.Text = "Arrêté";
        // 
        // headerStatusLabel
        // 
        this.headerStatusLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
        this.headerStatusLabel.AutoSize = true;
        this.headerStatusLabel.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
        this.headerStatusLabel.ForeColor = System.Drawing.Color.White;
        this.headerStatusLabel.Location = new System.Drawing.Point(1016, 18);
        this.headerStatusLabel.Name = "headerStatusLabel";
        this.headerStatusLabel.Size = new System.Drawing.Size(59, 19);
        this.headerStatusLabel.TabIndex = 3;
        this.headerStatusLabel.Text = "Statut : ";
        // 
        // headerSubtitleLabel
        // 
        this.headerSubtitleLabel.AutoSize = true;
        this.headerSubtitleLabel.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
        this.headerSubtitleLabel.ForeColor = System.Drawing.Color.WhiteSmoke;
        this.headerSubtitleLabel.Location = new System.Drawing.Point(96, 49);
        this.headerSubtitleLabel.Name = "headerSubtitleLabel";
        this.headerSubtitleLabel.Size = new System.Drawing.Size(383, 19);
        this.headerSubtitleLabel.TabIndex = 2;
        this.headerSubtitleLabel.Text = "Flux RTP H.265 (rtpjitterbuffer + d3dvideosink intégré)";
        // 
        // headerTitleLabel
        // 
        this.headerTitleLabel.AutoSize = true;
        this.headerTitleLabel.Font = new System.Drawing.Font("Segoe UI Semibold", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
        this.headerTitleLabel.ForeColor = System.Drawing.Color.White;
        this.headerTitleLabel.Location = new System.Drawing.Point(94, 16);
        this.headerTitleLabel.Name = "headerTitleLabel";
        this.headerTitleLabel.Size = new System.Drawing.Size(161, 25);
        this.headerTitleLabel.TabIndex = 1;
        this.headerTitleLabel.Text = "G-AM View Player";
        // 
        // headerLogoPictureBox
        // 
        this.headerLogoPictureBox.Location = new System.Drawing.Point(12, 10);
        this.headerLogoPictureBox.Name = "headerLogoPictureBox";
        this.headerLogoPictureBox.Size = new System.Drawing.Size(70, 70);
        this.headerLogoPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
        this.headerLogoPictureBox.TabIndex = 0;
        this.headerLogoPictureBox.TabStop = false;
        // 
        // mainTabs
        // 
        this.mainTabs.Controls.Add(this.playbackTab);
        this.mainTabs.Controls.Add(this.optionsTab);
        this.mainTabs.Dock = System.Windows.Forms.DockStyle.Fill;
        this.mainTabs.Location = new System.Drawing.Point(0, 96);
        this.mainTabs.Name = "mainTabs";
        this.mainTabs.SelectedIndex = 0;
        this.mainTabs.Size = new System.Drawing.Size(1184, 565);
        this.mainTabs.TabIndex = 1;
        // 
        // playbackTab
        // 
        this.playbackTab.Controls.Add(this.videoPanel);
        this.playbackTab.Controls.Add(this.playbackControlsPanel);
        this.playbackTab.Location = new System.Drawing.Point(4, 24);
        this.playbackTab.Name = "playbackTab";
        this.playbackTab.Padding = new System.Windows.Forms.Padding(8);
        this.playbackTab.Size = new System.Drawing.Size(1176, 537);
        this.playbackTab.TabIndex = 0;
        this.playbackTab.Text = "Lecture";
        this.playbackTab.UseVisualStyleBackColor = true;
        // 
        // videoPanel
        // 
        this.videoPanel.BackColor = System.Drawing.Color.Black;
        this.videoPanel.Dock = System.Windows.Forms.DockStyle.Fill;
        this.videoPanel.Location = new System.Drawing.Point(8, 112);
        this.videoPanel.Name = "videoPanel";
        this.videoPanel.Size = new System.Drawing.Size(1160, 417);
        this.videoPanel.TabIndex = 2;
        // 
        // playbackControlsPanel
        // 
        this.playbackControlsPanel.Controls.Add(this.statsFlowPanel);
        this.playbackControlsPanel.Controls.Add(this.audioControlFlowPanel);
        this.playbackControlsPanel.Controls.Add(this.controlFlowPanel);
        this.playbackControlsPanel.Dock = System.Windows.Forms.DockStyle.Top;
        this.playbackControlsPanel.Location = new System.Drawing.Point(8, 8);
        this.playbackControlsPanel.Name = "playbackControlsPanel";
        this.playbackControlsPanel.Padding = new System.Windows.Forms.Padding(0, 0, 0, 6);
        this.playbackControlsPanel.Size = new System.Drawing.Size(1160, 152);
        this.playbackControlsPanel.TabIndex = 1;
        // 
        // audioControlFlowPanel
        // 
        this.audioControlFlowPanel.AutoSize = true;
        this.audioControlFlowPanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
        this.audioControlFlowPanel.Controls.Add(this.audioPortLabel);
        this.audioControlFlowPanel.Controls.Add(this.audioPortTextBox);
        this.audioControlFlowPanel.Controls.Add(this.audioStartButton);
        this.audioControlFlowPanel.Controls.Add(this.audioStopButton);
        this.audioControlFlowPanel.Controls.Add(this.audioVolumeLabel);
        this.audioControlFlowPanel.Controls.Add(this.audioVolumeTrackBar);
        this.audioControlFlowPanel.Controls.Add(this.audioVolumeValueLabel);
        this.audioControlFlowPanel.Controls.Add(this.audioStatusLabel);
        this.audioControlFlowPanel.Controls.Add(this.audioStatusValueLabel);
        this.audioControlFlowPanel.FlowDirection = System.Windows.Forms.FlowDirection.LeftToRight;
        this.audioControlFlowPanel.Location = new System.Drawing.Point(0, 50);
        this.audioControlFlowPanel.Name = "audioControlFlowPanel";
        this.audioControlFlowPanel.Padding = new System.Windows.Forms.Padding(0, 2, 0, 0);
        this.audioControlFlowPanel.Size = new System.Drawing.Size(860, 32);
        this.audioControlFlowPanel.TabIndex = 1;
        this.audioControlFlowPanel.WrapContents = false;
        // 
        // audioPortLabel
        // 
        this.audioPortLabel.AutoSize = true;
        this.audioPortLabel.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
        this.audioPortLabel.Location = new System.Drawing.Point(0, 2);
        this.audioPortLabel.Margin = new System.Windows.Forms.Padding(0, 0, 6, 0);
        this.audioPortLabel.Name = "audioPortLabel";
        this.audioPortLabel.Size = new System.Drawing.Size(83, 19);
        this.audioPortLabel.TabIndex = 0;
        this.audioPortLabel.Text = "Port audio :";
        // 
        // audioPortTextBox
        // 
        this.audioPortTextBox.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
        this.audioPortTextBox.Location = new System.Drawing.Point(89, 2);
        this.audioPortTextBox.Margin = new System.Windows.Forms.Padding(0, 0, 12, 0);
        this.audioPortTextBox.Name = "audioPortTextBox";
        this.audioPortTextBox.Size = new System.Drawing.Size(80, 25);
        this.audioPortTextBox.TabIndex = 1;
        this.audioPortTextBox.Text = "5003";
        // 
        // audioStartButton
        // 
        this.audioStartButton.AutoSize = true;
        this.audioStartButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(94)))), ((int)(((byte)(32)))));
        this.audioStartButton.FlatAppearance.BorderSize = 0;
        this.audioStartButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
        this.audioStartButton.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
        this.audioStartButton.ForeColor = System.Drawing.Color.White;
        this.audioStartButton.Location = new System.Drawing.Point(181, 2);
        this.audioStartButton.Margin = new System.Windows.Forms.Padding(0, 0, 8, 0);
        this.audioStartButton.Name = "audioStartButton";
        this.audioStartButton.Size = new System.Drawing.Size(130, 27);
        this.audioStartButton.TabIndex = 2;
        this.audioStartButton.Text = "Démarrer audio";
        this.audioStartButton.UseVisualStyleBackColor = false;
        this.audioStartButton.Click += new System.EventHandler(this.AudioStartButton_Click);
        // 
        // audioStopButton
        // 
        this.audioStopButton.AutoSize = true;
        this.audioStopButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(183)))), ((int)(((byte)(28)))), ((int)(((byte)(28)))));
        this.audioStopButton.FlatAppearance.BorderSize = 0;
        this.audioStopButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
        this.audioStopButton.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
        this.audioStopButton.ForeColor = System.Drawing.Color.White;
        this.audioStopButton.Location = new System.Drawing.Point(319, 2);
        this.audioStopButton.Margin = new System.Windows.Forms.Padding(0, 0, 12, 0);
        this.audioStopButton.Name = "audioStopButton";
        this.audioStopButton.Size = new System.Drawing.Size(113, 27);
        this.audioStopButton.TabIndex = 3;
        this.audioStopButton.Text = "Arrêter audio";
        this.audioStopButton.UseVisualStyleBackColor = false;
        this.audioStopButton.Click += new System.EventHandler(this.AudioStopButton_Click);
        // 
        // audioVolumeLabel
        // 
        this.audioVolumeLabel.AutoSize = true;
        this.audioVolumeLabel.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
        this.audioVolumeLabel.Location = new System.Drawing.Point(444, 2);
        this.audioVolumeLabel.Margin = new System.Windows.Forms.Padding(0, 0, 6, 0);
        this.audioVolumeLabel.Name = "audioVolumeLabel";
        this.audioVolumeLabel.Size = new System.Drawing.Size(63, 19);
        this.audioVolumeLabel.TabIndex = 4;
        this.audioVolumeLabel.Text = "Volume :";
        // 
        // audioVolumeTrackBar
        // 
        this.audioVolumeTrackBar.AutoSize = false;
        this.audioVolumeTrackBar.LargeChange = 10;
        this.audioVolumeTrackBar.Location = new System.Drawing.Point(513, 2);
        this.audioVolumeTrackBar.Margin = new System.Windows.Forms.Padding(0, 0, 8, 0);
        this.audioVolumeTrackBar.Maximum = 400;
        this.audioVolumeTrackBar.Name = "audioVolumeTrackBar";
        this.audioVolumeTrackBar.Size = new System.Drawing.Size(180, 27);
        this.audioVolumeTrackBar.TabIndex = 5;
        this.audioVolumeTrackBar.TickFrequency = 50;
        this.audioVolumeTrackBar.Scroll += new System.EventHandler(this.AudioVolumeTrackBarOnScroll);
        // 
        // audioVolumeValueLabel
        // 
        this.audioVolumeValueLabel.AutoSize = true;
        this.audioVolumeValueLabel.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
        this.audioVolumeValueLabel.Location = new System.Drawing.Point(701, 2);
        this.audioVolumeValueLabel.Margin = new System.Windows.Forms.Padding(0, 0, 12, 0);
        this.audioVolumeValueLabel.Name = "audioVolumeValueLabel";
        this.audioVolumeValueLabel.Size = new System.Drawing.Size(35, 19);
        this.audioVolumeValueLabel.TabIndex = 6;
        this.audioVolumeValueLabel.Text = "2.00";
        // 
        // audioStatusLabel
        // 
        this.audioStatusLabel.AutoSize = true;
        this.audioStatusLabel.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
        this.audioStatusLabel.Location = new System.Drawing.Point(589, 2);
        this.audioStatusLabel.Margin = new System.Windows.Forms.Padding(0, 0, 4, 0);
        this.audioStatusLabel.Name = "audioStatusLabel";
        this.audioStatusLabel.Size = new System.Drawing.Size(53, 19);
        this.audioStatusLabel.TabIndex = 7;
        this.audioStatusLabel.Text = "Statut :";
        // 
        // audioStatusValueLabel
        // 
        this.audioStatusValueLabel.AutoSize = true;
        this.audioStatusValueLabel.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
        this.audioStatusValueLabel.Location = new System.Drawing.Point(646, 2);
        this.audioStatusValueLabel.Margin = new System.Windows.Forms.Padding(0);
        this.audioStatusValueLabel.Name = "audioStatusValueLabel";
        this.audioStatusValueLabel.Size = new System.Drawing.Size(49, 19);
        this.audioStatusValueLabel.TabIndex = 8;
        this.audioStatusValueLabel.Text = "Arrêté";
        // 
        // 
        // statsFlowPanel
        // 
        this.statsFlowPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
        this.statsFlowPanel.AutoSize = true;
        this.statsFlowPanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
        this.statsFlowPanel.Controls.Add(this.bitrateLabel);
        this.statsFlowPanel.Controls.Add(this.bitrateValueLabel);
        this.statsFlowPanel.Controls.Add(this.fpsLabel);
        this.statsFlowPanel.Controls.Add(this.fpsValueLabel);
        this.statsFlowPanel.Controls.Add(this.latencyLabel);
        this.statsFlowPanel.Controls.Add(this.latencyValueLabel);
        this.statsFlowPanel.Controls.Add(this.lossLabel);
        this.statsFlowPanel.Controls.Add(this.lossValueLabel);
        this.statsFlowPanel.Controls.Add(this.lastPacketLabel);
        this.statsFlowPanel.Controls.Add(this.lastPacketValueLabel);
        this.statsFlowPanel.FlowDirection = System.Windows.Forms.FlowDirection.LeftToRight;
        this.statsFlowPanel.Location = new System.Drawing.Point(480, 104);
        this.statsFlowPanel.Name = "statsFlowPanel";
        this.statsFlowPanel.Padding = new System.Windows.Forms.Padding(4, 4, 4, 0);
        this.statsFlowPanel.Size = new System.Drawing.Size(674, 34);
        this.statsFlowPanel.TabIndex = 2;
        this.statsFlowPanel.WrapContents = false;
        // 
        // bitrateLabel
        // 
        this.bitrateLabel.AutoSize = true;
        this.bitrateLabel.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
        this.bitrateLabel.Location = new System.Drawing.Point(4, 4);
        this.bitrateLabel.Margin = new System.Windows.Forms.Padding(0, 0, 4, 0);
        this.bitrateLabel.Name = "bitrateLabel";
        this.bitrateLabel.Size = new System.Drawing.Size(50, 19);
        this.bitrateLabel.TabIndex = 0;
        this.bitrateLabel.Text = "Débit :";
        // 
        // bitrateValueLabel
        // 
        this.bitrateValueLabel.AutoSize = true;
        this.bitrateValueLabel.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
        this.bitrateValueLabel.Location = new System.Drawing.Point(58, 4);
        this.bitrateValueLabel.Margin = new System.Windows.Forms.Padding(0, 0, 16, 0);
        this.bitrateValueLabel.Name = "bitrateValueLabel";
        this.bitrateValueLabel.Size = new System.Drawing.Size(23, 19);
        this.bitrateValueLabel.TabIndex = 1;
        this.bitrateValueLabel.Text = "- ";
        // 
        // fpsLabel
        // 
        this.fpsLabel.AutoSize = true;
        this.fpsLabel.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
        this.fpsLabel.Location = new System.Drawing.Point(97, 4);
        this.fpsLabel.Margin = new System.Windows.Forms.Padding(0, 0, 4, 0);
        this.fpsLabel.Name = "fpsLabel";
        this.fpsLabel.Size = new System.Drawing.Size(39, 19);
        this.fpsLabel.TabIndex = 2;
        this.fpsLabel.Text = "FPS :";
        // 
        // fpsValueLabel
        // 
        this.fpsValueLabel.AutoSize = true;
        this.fpsValueLabel.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
        this.fpsValueLabel.Location = new System.Drawing.Point(140, 4);
        this.fpsValueLabel.Margin = new System.Windows.Forms.Padding(0, 0, 16, 0);
        this.fpsValueLabel.Name = "fpsValueLabel";
        this.fpsValueLabel.Size = new System.Drawing.Size(23, 19);
        this.fpsValueLabel.TabIndex = 3;
        this.fpsValueLabel.Text = "- ";
        // 
        // latencyLabel
        // 
        this.latencyLabel.AutoSize = true;
        this.latencyLabel.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
        this.latencyLabel.Location = new System.Drawing.Point(179, 4);
        this.latencyLabel.Margin = new System.Windows.Forms.Padding(0, 0, 4, 0);
        this.latencyLabel.Name = "latencyLabel";
        this.latencyLabel.Size = new System.Drawing.Size(64, 19);
        this.latencyLabel.TabIndex = 4;
        this.latencyLabel.Text = "Latence :";
        // 
        // latencyValueLabel
        // 
        this.latencyValueLabel.AutoSize = true;
        this.latencyValueLabel.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
        this.latencyValueLabel.Location = new System.Drawing.Point(247, 4);
        this.latencyValueLabel.Margin = new System.Windows.Forms.Padding(0, 0, 16, 0);
        this.latencyValueLabel.Name = "latencyValueLabel";
        this.latencyValueLabel.Size = new System.Drawing.Size(23, 19);
        this.latencyValueLabel.TabIndex = 5;
        this.latencyValueLabel.Text = "- ";
        // 
        // lossLabel
        // 
        this.lossLabel.AutoSize = true;
        this.lossLabel.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
        this.lossLabel.Location = new System.Drawing.Point(286, 4);
        this.lossLabel.Margin = new System.Windows.Forms.Padding(0, 0, 4, 0);
        this.lossLabel.Name = "lossLabel";
        this.lossLabel.Size = new System.Drawing.Size(52, 19);
        this.lossLabel.TabIndex = 6;
        this.lossLabel.Text = "Pertes :";
        // 
        // lossValueLabel
        // 
        this.lossValueLabel.AutoSize = true;
        this.lossValueLabel.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
        this.lossValueLabel.Location = new System.Drawing.Point(342, 4);
        this.lossValueLabel.Margin = new System.Windows.Forms.Padding(0, 0, 16, 0);
        this.lossValueLabel.Name = "lossValueLabel";
        this.lossValueLabel.Size = new System.Drawing.Size(23, 19);
        this.lossValueLabel.TabIndex = 7;
        this.lossValueLabel.Text = "- ";
        // 
        // lastPacketLabel
        // 
        this.lastPacketLabel.AutoSize = true;
        this.lastPacketLabel.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
        this.lastPacketLabel.Location = new System.Drawing.Point(381, 4);
        this.lastPacketLabel.Margin = new System.Windows.Forms.Padding(0, 0, 4, 0);
        this.lastPacketLabel.Name = "lastPacketLabel";
        this.lastPacketLabel.Size = new System.Drawing.Size(111, 19);
        this.lastPacketLabel.TabIndex = 8;
        this.lastPacketLabel.Text = "Dernier paquet :";
        // 
        // lastPacketValueLabel
        // 
        this.lastPacketValueLabel.AutoSize = true;
        this.lastPacketValueLabel.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
        this.lastPacketValueLabel.Location = new System.Drawing.Point(496, 4);
        this.lastPacketValueLabel.Margin = new System.Windows.Forms.Padding(0, 0, 16, 0);
        this.lastPacketValueLabel.Name = "lastPacketValueLabel";
        this.lastPacketValueLabel.Size = new System.Drawing.Size(23, 19);
        this.lastPacketValueLabel.TabIndex = 9;
        this.lastPacketValueLabel.Text = "- ";
        // 
        // controlFlowPanel
        // 
        this.controlFlowPanel.AutoSize = true;
        this.controlFlowPanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
        this.controlFlowPanel.Controls.Add(this.portLabel);
        this.controlFlowPanel.Controls.Add(this.portTextBox);
        this.controlFlowPanel.Controls.Add(this.startButton);
        this.controlFlowPanel.Controls.Add(this.stopButton);
        this.controlFlowPanel.FlowDirection = System.Windows.Forms.FlowDirection.LeftToRight;
        this.controlFlowPanel.Location = new System.Drawing.Point(0, 10);
        this.controlFlowPanel.Name = "controlFlowPanel";
        this.controlFlowPanel.Padding = new System.Windows.Forms.Padding(0, 2, 0, 0);
        this.controlFlowPanel.Size = new System.Drawing.Size(349, 32);
        this.controlFlowPanel.TabIndex = 0;
        this.controlFlowPanel.WrapContents = false;
        // 
        // portLabel
        // 
        this.portLabel.AutoSize = true;
        this.portLabel.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
        this.portLabel.Location = new System.Drawing.Point(0, 2);
        this.portLabel.Margin = new System.Windows.Forms.Padding(0, 0, 6, 0);
        this.portLabel.Name = "portLabel";
        this.portLabel.Size = new System.Drawing.Size(78, 19);
        this.portLabel.TabIndex = 0;
        this.portLabel.Text = "Port UDP :";
        // 
        // portTextBox
        // 
        this.portTextBox.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
        this.portTextBox.Location = new System.Drawing.Point(84, 2);
        this.portTextBox.Margin = new System.Windows.Forms.Padding(0, 0, 12, 0);
        this.portTextBox.Name = "portTextBox";
        this.portTextBox.Size = new System.Drawing.Size(80, 25);
        this.portTextBox.TabIndex = 1;
        this.portTextBox.Text = "5001";
        // 
        // startButton
        // 
        this.startButton.AutoSize = true;
        this.startButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(94)))), ((int)(((byte)(32)))));
        this.startButton.FlatAppearance.BorderSize = 0;
        this.startButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
        this.startButton.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
        this.startButton.ForeColor = System.Drawing.Color.White;
        this.startButton.Location = new System.Drawing.Point(176, 2);
        this.startButton.Margin = new System.Windows.Forms.Padding(0, 0, 8, 0);
        this.startButton.Name = "startButton";
        this.startButton.Size = new System.Drawing.Size(88, 27);
        this.startButton.TabIndex = 2;
        this.startButton.Text = "Démarrer";
        this.startButton.UseVisualStyleBackColor = false;
        this.startButton.Click += new System.EventHandler(this.StartButton_Click);
        // 
        // stopButton
        // 
        this.stopButton.AutoSize = true;
        this.stopButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(183)))), ((int)(((byte)(28)))), ((int)(((byte)(28)))));
        this.stopButton.FlatAppearance.BorderSize = 0;
        this.stopButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
        this.stopButton.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
        this.stopButton.ForeColor = System.Drawing.Color.White;
        this.stopButton.Location = new System.Drawing.Point(272, 2);
        this.stopButton.Margin = new System.Windows.Forms.Padding(0, 0, 12, 0);
        this.stopButton.Name = "stopButton";
        this.stopButton.Size = new System.Drawing.Size(65, 27);
        this.stopButton.TabIndex = 3;
        this.stopButton.Text = "Arrêter";
        this.stopButton.UseVisualStyleBackColor = false;
        this.stopButton.Click += new System.EventHandler(this.StopButton_Click);
        // 
        // optionsTab
        // 
        this.optionsTab.Controls.Add(this.optionsInfoLabel);
        this.optionsTab.Controls.Add(this.applyOptionsButton);
        this.optionsTab.Controls.Add(this.gstPathTextBox);
        this.optionsTab.Controls.Add(this.gstPathLabel);
        this.optionsTab.Controls.Add(this.clockPortTextBox);
        this.optionsTab.Controls.Add(this.clockPortLabel);
        this.optionsTab.Controls.Add(this.resetAudioPipelineButton);
        this.optionsTab.Controls.Add(this.resetPipelineButton);
        this.optionsTab.Controls.Add(this.audioPipelineHintLabel);
        this.optionsTab.Controls.Add(this.pipelineHintLabel);
        this.optionsTab.Controls.Add(this.audioPipelineTextBox);
        this.optionsTab.Controls.Add(this.pipelineTextBox);
        this.optionsTab.Controls.Add(this.audioPipelineLabel);
        this.optionsTab.Controls.Add(this.pipelineLabel);
        this.optionsTab.Location = new System.Drawing.Point(4, 24);
        this.optionsTab.Name = "optionsTab";
        this.optionsTab.Padding = new System.Windows.Forms.Padding(12);
        this.optionsTab.Size = new System.Drawing.Size(1176, 537);
        this.optionsTab.TabIndex = 1;
        this.optionsTab.Text = "Options";
        this.optionsTab.UseVisualStyleBackColor = true;
        // 
        // optionsInfoLabel
        // 
        this.optionsInfoLabel.AutoSize = true;
        this.optionsInfoLabel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point);
        this.optionsInfoLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(90)))), ((int)(((byte)(90)))));
        this.optionsInfoLabel.Location = new System.Drawing.Point(16, 500);
        this.optionsInfoLabel.MaximumSize = new System.Drawing.Size(900, 0);
        this.optionsInfoLabel.Name = "optionsInfoLabel";
        this.optionsInfoLabel.Size = new System.Drawing.Size(643, 30);
        this.optionsInfoLabel.TabIndex = 13;
        this.optionsInfoLabel.Text = "Les variables d'environnement GStreamer sont mises à jour quand vous appliquez. " +
    "Si GStreamer n'est pas initialisé, le nouveau chemin sera utilisé au prochain dé" +
    "marrage de flux.";
        // 
        // applyOptionsButton
        // 
        this.applyOptionsButton.BackColor = System.Drawing.Color.Black;
        this.applyOptionsButton.FlatAppearance.BorderSize = 0;
        this.applyOptionsButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
        this.applyOptionsButton.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
        this.applyOptionsButton.ForeColor = System.Drawing.Color.White;
        this.applyOptionsButton.Location = new System.Drawing.Point(16, 468);
        this.applyOptionsButton.Name = "applyOptionsButton";
        this.applyOptionsButton.Size = new System.Drawing.Size(124, 32);
        this.applyOptionsButton.TabIndex = 12;
        this.applyOptionsButton.Text = "Appliquer";
        this.applyOptionsButton.UseVisualStyleBackColor = false;
        this.applyOptionsButton.Click += new System.EventHandler(this.ApplyOptionsButton_Click);
        // 
        // gstPathTextBox
        // 
        this.gstPathTextBox.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
        this.gstPathTextBox.Location = new System.Drawing.Point(16, 430);
        this.gstPathTextBox.Name = "gstPathTextBox";
        this.gstPathTextBox.Size = new System.Drawing.Size(600, 25);
        this.gstPathTextBox.TabIndex = 11;
        // 
        // gstPathLabel
        // 
        this.gstPathLabel.AutoSize = true;
        this.gstPathLabel.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
        this.gstPathLabel.Location = new System.Drawing.Point(12, 408);
        this.gstPathLabel.Name = "gstPathLabel";
        this.gstPathLabel.Size = new System.Drawing.Size(212, 19);
        this.gstPathLabel.TabIndex = 10;
        this.gstPathLabel.Text = "Chemin base GStreamer (bin/lib) :";
        // 
        // clockPortTextBox
        // 
        this.clockPortTextBox.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
        this.clockPortTextBox.Location = new System.Drawing.Point(16, 370);
        this.clockPortTextBox.Name = "clockPortTextBox";
        this.clockPortTextBox.Size = new System.Drawing.Size(120, 25);
        this.clockPortTextBox.TabIndex = 9;
        this.clockPortTextBox.Text = "5002";
        // 
        // clockPortLabel
        // 
        this.clockPortLabel.AutoSize = true;
        this.clockPortLabel.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
        this.clockPortLabel.Location = new System.Drawing.Point(12, 348);
        this.clockPortLabel.Name = "clockPortLabel";
        this.clockPortLabel.Size = new System.Drawing.Size(134, 19);
        this.clockPortLabel.TabIndex = 8;
        this.clockPortLabel.Text = "Port horloge (UDP) :";
        // resetPipelineButton
        // 
        this.resetPipelineButton.AutoSize = true;
        this.resetPipelineButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
        this.resetPipelineButton.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
        this.resetPipelineButton.Location = new System.Drawing.Point(1058, 16);
        this.resetPipelineButton.Name = "resetPipelineButton";
        this.resetPipelineButton.Size = new System.Drawing.Size(78, 27);
        this.resetPipelineButton.TabIndex = 3;
        this.resetPipelineButton.Text = "Par défaut";
        this.resetPipelineButton.UseVisualStyleBackColor = true;
        this.resetPipelineButton.Click += new System.EventHandler(this.ResetPipelineButton_Click);
        // 
        // resetAudioPipelineButton
        // 
        this.resetAudioPipelineButton.AutoSize = true;
        this.resetAudioPipelineButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
        this.resetAudioPipelineButton.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
        this.resetAudioPipelineButton.Location = new System.Drawing.Point(1058, 184);
        this.resetAudioPipelineButton.Name = "resetAudioPipelineButton";
        this.resetAudioPipelineButton.Size = new System.Drawing.Size(100, 27);
        this.resetAudioPipelineButton.TabIndex = 7;
        this.resetAudioPipelineButton.Text = "Par défaut audio";
        this.resetAudioPipelineButton.UseVisualStyleBackColor = true;
        this.resetAudioPipelineButton.Click += new System.EventHandler(this.ResetAudioPipelineButton_Click);
        // 
        // pipelineHintLabel
        // 
        this.pipelineHintLabel.AutoSize = true;
        this.pipelineHintLabel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point);
        this.pipelineHintLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(90)))), ((int)(((byte)(90)))));
        this.pipelineHintLabel.Location = new System.Drawing.Point(16, 144);
        this.pipelineHintLabel.MaximumSize = new System.Drawing.Size(900, 0);
        this.pipelineHintLabel.Name = "pipelineHintLabel";
        this.pipelineHintLabel.Size = new System.Drawing.Size(378, 30);
        this.pipelineHintLabel.TabIndex = 2;
        this.pipelineHintLabel.Text = "Utilisez {port} pour insérer automatiquement le port vidéo. Le sink doit supporter GstVideoOverlay (ex : d3dvideosink).";
        // 
        // audioPipelineHintLabel
        // 
        this.audioPipelineHintLabel.AutoSize = true;
        this.audioPipelineHintLabel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point);
        this.audioPipelineHintLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(90)))), ((int)(((byte)(90)))));
        this.audioPipelineHintLabel.Location = new System.Drawing.Point(16, 312);
        this.audioPipelineHintLabel.MaximumSize = new System.Drawing.Size(900, 0);
        this.audioPipelineHintLabel.Name = "audioPipelineHintLabel";
        this.audioPipelineHintLabel.Size = new System.Drawing.Size(551, 30);
        this.audioPipelineHintLabel.TabIndex = 6;
        this.audioPipelineHintLabel.Text = "Utilisez {port} pour insérer automatiquement le port audio. Ajoutez idéalement un élément \"volume\" nommé \"avol\" pour pouvoir ajuster le niveau.";
        // 
        // pipelineTextBox
        // 
        this.pipelineTextBox.AcceptsReturn = true;
        this.pipelineTextBox.AcceptsTab = true;
        this.pipelineTextBox.Font = new System.Drawing.Font("Consolas", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
        this.pipelineTextBox.Location = new System.Drawing.Point(16, 44);
        this.pipelineTextBox.Multiline = true;
        this.pipelineTextBox.Name = "pipelineTextBox";
        this.pipelineTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
        this.pipelineTextBox.Size = new System.Drawing.Size(1142, 96);
        this.pipelineTextBox.TabIndex = 1;
        // 
        // audioPipelineTextBox
        // 
        this.audioPipelineTextBox.AcceptsReturn = true;
        this.audioPipelineTextBox.AcceptsTab = true;
        this.audioPipelineTextBox.Font = new System.Drawing.Font("Consolas", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
        this.audioPipelineTextBox.Location = new System.Drawing.Point(16, 212);
        this.audioPipelineTextBox.Multiline = true;
        this.audioPipelineTextBox.Name = "audioPipelineTextBox";
        this.audioPipelineTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
        this.audioPipelineTextBox.Size = new System.Drawing.Size(1142, 96);
        this.audioPipelineTextBox.TabIndex = 5;
        // 
        // audioPipelineLabel
        // 
        this.audioPipelineLabel.AutoSize = true;
        this.audioPipelineLabel.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
        this.audioPipelineLabel.Location = new System.Drawing.Point(12, 188);
        this.audioPipelineLabel.Name = "audioPipelineLabel";
        this.audioPipelineLabel.Size = new System.Drawing.Size(146, 19);
        this.audioPipelineLabel.TabIndex = 4;
        this.audioPipelineLabel.Text = "Pipeline audio (code) :";
        // 
        // pipelineLabel
        // 
        this.pipelineLabel.AutoSize = true;
        this.pipelineLabel.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
        this.pipelineLabel.Location = new System.Drawing.Point(12, 20);
        this.pipelineLabel.Name = "pipelineLabel";
        this.pipelineLabel.Size = new System.Drawing.Size(166, 19);
        this.pipelineLabel.TabIndex = 0;
        this.pipelineLabel.Text = "Pipeline vidéo (code) :";
        // 
        // MainForm
        // 
        this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        this.BackColor = System.Drawing.Color.White;
        this.ClientSize = new System.Drawing.Size(1184, 661);
        this.Controls.Add(this.mainTabs);
        this.Controls.Add(this.headerPanel);
        this.MinimumSize = new System.Drawing.Size(900, 540);
        this.Name = "MainForm";
        this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
        this.Text = "G-AM View";
        this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
        this.headerPanel.ResumeLayout(false);
        this.headerPanel.PerformLayout();
        ((System.ComponentModel.ISupportInitialize)(this.headerLogoPictureBox)).EndInit();
        this.mainTabs.ResumeLayout(false);
        this.playbackTab.ResumeLayout(false);
        this.playbackControlsPanel.ResumeLayout(false);
        this.playbackControlsPanel.PerformLayout();
        this.audioControlFlowPanel.ResumeLayout(false);
        this.audioControlFlowPanel.PerformLayout();
        this.statsFlowPanel.ResumeLayout(false);
        this.statsFlowPanel.PerformLayout();
        this.controlFlowPanel.ResumeLayout(false);
        this.controlFlowPanel.PerformLayout();
        this.optionsTab.ResumeLayout(false);
        this.optionsTab.PerformLayout();
        ((System.ComponentModel.ISupportInitialize)(this.audioVolumeTrackBar)).EndInit();
        this.ResumeLayout(false);

    }

    #endregion
}
