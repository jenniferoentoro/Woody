using System;
using OpenTK.Windowing.Desktop;
using LearnOpenTK.Common;

namespace Woody
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var nativeWindowSettings = new NativeWindowSettings()
            {
                Size = new OpenTK.Mathematics.Vector2i(800, 800),
                Title = "Proyek 1 Grafika Komputer"
            };

            using (var window = new Window(GameWindowSettings.Default, nativeWindowSettings))
            {
                window.Run();
            }
        }

    }
}
