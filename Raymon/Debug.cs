using Raylib_cs;

namespace RaymonApp
{
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
