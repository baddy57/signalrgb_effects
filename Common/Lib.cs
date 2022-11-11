using System;
using System.Diagnostics;
using System.Reflection;

namespace Common;

public class Lib
{
    //https://www.nirsoft.net/utils/nircmd.html
    public static async Task MinimizeSignalRGB()
    {
        await Task.Delay(1000);
        string cmd = $"{System.AppContext.BaseDirectory}\\nircmd.exe";
        string args = "win min process SignalRgb.exe";
        var ps = new ProcessStartInfo(cmd)
        {
            Arguments = args
        };
        Process.Start(ps);
    }
}