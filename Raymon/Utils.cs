using Raylib_cs;
using System.Numerics;

namespace RaymonApp;

public static class Utils
{
    public static Vector2 GetCenteredTextPosition(Vector2 target, string msg, int fontSize)
    {
        return new Vector2(target.X - Raylib.MeasureText(msg, fontSize) / 2, target.Y - fontSize / 2);
    }

    public static void DrawTextCentered(string msg, Vector2 pos)
    {
        Vector2 posCentered = GetCenteredTextPosition(pos, msg, AppData.FontSize);
        Raylib.DrawText(msg, (int)posCentered.X, (int)posCentered.Y, AppData.FontSize, Color.Red);
    }

    public static Rectangle GetCenteredRect(int x, int y, int w, int h)
    {
        return new Rectangle(x - w / 2, y - h / 2, w, h);
    }
}
