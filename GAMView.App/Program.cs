using System;
using System.IO;
using System.Windows.Forms;

namespace GAMView.App;

internal static class Program
{
    private const string FallbackGstBasePath = @"C:\gstreamer\1.0\msvc_x86_64";

    public static string DefaultGstBasePath => FallbackGstBasePath;

    [STAThread]
    private static void Main()
    {
        ConfigureGStreamerEnvironment(DefaultGstBasePath);

        ApplicationConfiguration.Initialize();
        Application.Run(new MainForm());
    }

    public static void ConfigureGStreamerEnvironment(string? basePath)
    {
        var root = string.IsNullOrWhiteSpace(basePath) ? FallbackGstBasePath : basePath.Trim();
        var binPath = Path.Combine(root, "bin");
        var pluginPath = Path.Combine(root, "lib", "gstreamer-1.0");

        PrependPath("PATH", binPath);
        if (Directory.Exists(pluginPath))
        {
            Environment.SetEnvironmentVariable("GST_PLUGIN_PATH", pluginPath);
        }
    }

    private static void PrependPath(string key, string newPath)
    {
        if (string.IsNullOrWhiteSpace(newPath) || !Directory.Exists(newPath))
        {
            return;
        }

        var current = Environment.GetEnvironmentVariable(key) ?? string.Empty;
        var segments = current.Split(';', StringSplitOptions.RemoveEmptyEntries);
        foreach (var segment in segments)
        {
            if (string.Equals(segment.Trim(), newPath, StringComparison.OrdinalIgnoreCase))
            {
                return;
            }
        }

        var updated = string.IsNullOrWhiteSpace(current) ? newPath : $"{newPath};{current}";
        Environment.SetEnvironmentVariable(key, updated);
    }
}
