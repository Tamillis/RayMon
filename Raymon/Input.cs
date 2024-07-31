using Raylib_cs;

namespace RaymonApp;

public static class Input
{
    public static bool KeyPressed(KeyboardKey key)
    {
        return Raylib.IsKeyPressed(key);
    }

    public static bool KeysPressed(params KeyboardKey[] keys)
    {
        foreach (var key in keys) if (Raylib.IsKeyDown(key)) return true;

        return false;
    }
}
