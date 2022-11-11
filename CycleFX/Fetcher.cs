using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CycleFX
{
    public class Fetcher
    {
        public static IEnumerable<Fx> Fetch()
        {
            string appdatalocal = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
            var dir = Path.Combine(appdatalocal, @"WhirlwindFX\SignalRgb\cache\effects");

            var fxdirs = Directory.GetDirectories(dir);

            foreach (var fxDir in fxdirs)
            {
                var filePath = Path.Combine(fxDir, "effect.html");
                if (File.Exists(filePath))
                {
                    var text = File.ReadAllText(filePath);
                    var tag = Regex.Match(text, "<title>.*</title>").Value;
                    var title = tag.Replace("<title>", "");
                    title = title.Replace("</title>", "");
                    Console.WriteLine(title);
                    yield return new Fx() { Title = title, dir = fxDir };
                }
            }
        }

        public static Fx getnext()
        {
            var fxs = Fetch();

            var path = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            var currentFxPath = Path.Combine(path, "current_fx.txt");

            int currentFx;
            try { currentFx = int.Parse(File.ReadAllText(currentFxPath)); }
            catch { currentFx = 0; }

            int tot = fxs.Count();
            currentFx = ++currentFx % tot;

            File.WriteAllText(currentFxPath, (++currentFx).ToString());

            return fxs.ElementAt(currentFx);
        }
    }
}