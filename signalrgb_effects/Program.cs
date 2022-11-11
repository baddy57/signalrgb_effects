// See https://aka.ms/new-console-template for more information
using System.Text.RegularExpressions;

string appdatalocal = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
var dir = Path.Combine(appdatalocal, @"WhirlwindFX\SignalRgb\cache\effects");

var fxDirs = Directory.GetDirectories(dir);

List<string> fxs = new();

foreach (var fxDir in fxDirs)
{
    var filePath = Path.Combine(fxDir, "effect.html");
    if (File.Exists(filePath))
    {
        var text = File.ReadAllText(filePath);
        var tag = Regex.Match(text, "<title>.*</title>").Value;
        var title = tag.Replace("<title>", "");
        title = title.Replace("</title>", "");
        title = title.Replace(" ", "%20");
        fxs.Add(title);
        Console.WriteLine(title);
    }
}
var outPath = @"c:\script\effects.txt";
File.WriteAllLines(outPath, fxs);