using System.Diagnostics;

var path = @"c:\script";
var fxListPath = Path.Combine(path, "effects.txt");
var currentFxPath = Path.Combine(path, "current_fx.txt");
int currentFx;
try
{
    currentFx = int.Parse(File.ReadAllText(currentFxPath));
}
catch (Exception ex)
{
    currentFx = 0;
}

var fxs = File.ReadLines(fxListPath);
int tot = fxs.Count();
var cmd = $"signalrgb://effect/apply/{fxs.ElementAt((++currentFx) % tot)}";
//var cmd = $"start signalrgb://effect/apply/{fxs.ElementAt((++currentFx) % tot)}";
//cmd = @"C:\script\"
File.WriteAllText(currentFxPath, currentFx.ToString());

//Process process = new Process();
// Configure the process using the StartInfo properties.
//process.StartInfo.FileName = "start";
//process.StartInfo.Arguments = cmd;
//process.StartInfo.WindowStyle = ProcessWindowStyle.Maximized;
//process.Start();
//process.StartInfo.WindowStyle = ProcessWindowStyle.Maximized;
var ps = new ProcessStartInfo(cmd)
{
    UseShellExecute = true,
    Verb = "open"
};
Process.Start(ps);

//Process.Start(cmd);