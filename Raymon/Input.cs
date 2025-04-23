using Raylib_cs;

namespace RaymonApp;

/// <summary>
/// Wrapper for Raylib methods & associated input utilities
/// </summary>
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

    public static bool MoveKeysPressed()
    {
        var moveKeys = new KeyboardKey[] { 
            KeyboardKey.W, 
            KeyboardKey.A, 
            KeyboardKey.S, 
            KeyboardKey.D, 
            KeyboardKey.Up, 
            KeyboardKey.Down, 
            KeyboardKey.Left, 
            KeyboardKey.Right 
        };

        return KeysPressed(moveKeys);
    }
}
