using Common;
using System.Diagnostics;

void exec(string cmd)
{
    var ps = new ProcessStartInfo(cmd)
    {
        UseShellExecute = true,
        Verb = "open"
    };
    Process.Start(ps);
}

//string escape = "^&";

//string install = "signalrgb://effect/install/Solid%20Color";
string apply = "signalrgb://effect/apply/Solid%20Color?color=0";

//if (args.Length > 0 && args[0].Equals("-i"))
//{
//    exec(install);
//}
//else
//{
exec(apply);
//}

_ = Lib.MinimizeSignalRGB();