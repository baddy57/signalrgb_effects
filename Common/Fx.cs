using System.Diagnostics;
using System.IO;

namespace CycleFX
{
    public class Fx
    {
        public string Title;
        public string Imgpath { get => Path.Combine(dir, "image.png"); }
        public string dir;
        public string id { get => Title.Replace(" ", "%20"); }
        public string cmd { get => $"signalrgb://effect/apply/{id}"; }

        public void apply()
        {
            var ps = new ProcessStartInfo(cmd)
            {
                UseShellExecute = true,
                Verb = "open"
            };
            Process.Start(ps);
        }
    }
}