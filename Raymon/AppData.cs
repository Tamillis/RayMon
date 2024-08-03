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

    public static class Debug
    {
        public static int FontSize { get; set; } = 16;
        public static List<string> Data = new List<string>();

        public static void SetData(string datum)
        {
            Data.Add(datum);
        }

        public static void ClearData()
        {
            Data = new List<string>();
        }

        public static void Draw()
        {
            int debugWidth = Data.Select(str => Raylib.MeasureText(str, FontSize)).Max();
            Raylib.DrawRectangle(0, 0, debugWidth, FontSize * (Data.Count + 1), Color.Black);
            Raylib.DrawText("Debug:", 0, 0, FontSize, Color.White);
            for (int i = 0; i < Data.Count; i++)
            {
                Raylib.DrawText(Data[i], 0, FontSize * (i + 1), FontSize, Color.White);
            }
        }
    }
}
