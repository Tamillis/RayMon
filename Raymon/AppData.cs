using Raylib_cs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RaymonApp
{
    //TODO: set this from external app settings json or some such
    public static class AppData
    {
        public static readonly int W = 32 * 32;
        public static readonly int H = 24 * 32;
        public static readonly int WorldSize = 100;
        public static readonly int FontSize = 16;
        public static readonly int SpriteScale = 32;

        public static bool Debug = true;
        public static double Delta = 0f;
        public static readonly double TickDuration = 0.166; //6 ticks a second
        public static readonly double EntityBaseSpeed = 1;  //base scale for entity speed
    }
}
