using Raylib_cs;
using System.Numerics;

namespace RaymonApp;

public static class SpriteMap
{
    public static readonly Vector2 GRASS = new Vector2(0, 0);
    public static readonly Vector2 TREE_TOP = new Vector2(0, 1);
    public static readonly Vector2 TREE_TRUNK = new Vector2(0, 2);
    public static readonly Vector2 SKY = new Vector2(1, 0);

    public static readonly Vector2 PLAYER_FRONT_0 = new Vector2(0, 0);
    public static readonly Vector2 PLAYER_FRONT_1 = new Vector2(0, 1);
    public static readonly Vector2 PLAYER_FRONT_2 = new Vector2(0, 2);
    public static readonly Vector2 PLAYER_FRONT_3 = new Vector2(0, 3);
    public static readonly List<Vector2> PLAYER_MOVE_FRONT = new List<Vector2>() { PLAYER_FRONT_0, PLAYER_FRONT_1, PLAYER_FRONT_2, PLAYER_FRONT_3 };

    public static readonly Vector2 PLAYER_BACK_0 = new Vector2(1, 0);
    public static readonly Vector2 PLAYER_BACK_1 = new Vector2(1, 1);
    public static readonly Vector2 PLAYER_BACK_2 = new Vector2(1, 2);
    public static readonly Vector2 PLAYER_BACK_3 = new Vector2(1, 3);
    public static readonly List<Vector2> PLAYER_MOVE_BACK = new List<Vector2>() { PLAYER_BACK_0, PLAYER_BACK_1, PLAYER_BACK_2, PLAYER_BACK_3 };

    public static readonly Vector2 PLAYER_LEFT_0 = new Vector2(2, 0);
    public static readonly Vector2 PLAYER_LEFT_1 = new Vector2(2, 1);
    public static readonly Vector2 PLAYER_LEFT_2 = new Vector2(2, 2);
    public static readonly Vector2 PLAYER_LEFT_3 = new Vector2(2, 3);
    public static readonly List<Vector2> PLAYER_MOVE_LEFT = new List<Vector2>() { PLAYER_LEFT_0, PLAYER_LEFT_1, PLAYER_LEFT_2, PLAYER_LEFT_3 };

    public static readonly Vector2 PLAYER_RIGHT_0 = new Vector2(3, 0);
    public static readonly Vector2 PLAYER_RIGHT_1 = new Vector2(3, 1);
    public static readonly Vector2 PLAYER_RIGHT_2 = new Vector2(3, 2);
    public static readonly Vector2 PLAYER_RIGHT_3 = new Vector2(3, 3);
    public static readonly List<Vector2> PLAYER_MOVE_RIGHT = new List<Vector2>() { PLAYER_RIGHT_1, PLAYER_RIGHT_0, PLAYER_RIGHT_2, PLAYER_RIGHT_0 };
}

/// <summary>
/// Manages animation (if multiple frames) so getting the vector2 for the draw call
/// </summary>
public class Sprite
{
    ////single sprite spritesheet, the number of frames determined by the width of the sheet
    //public Sprite(SpriteSheet spriteSheet)
    //{
    //    int numOfFrames = spriteSheet.Texture.Width / AppData.SpriteScale;

    //    for (int i = 0; i < numOfFrames; i++)
    //    {
    //        Frames = new List<Vector2>() { new Vector2(i, 0) };
    //    }
    //}

    //single frame sprite
    public Sprite(Vector2 sprite)
    {
        Frames = new List<Vector2>() { sprite };
    }

    //multiframe sprite
    public Sprite(List<Vector2> frames)
    {
        Frames = frames;
    }

    private int CurrFrame = 0;
    private double delta = 0;

    public int NextFrame()
    {
        int nextFrame = CurrFrame + 1;
        if (nextFrame >= Frames.Count) nextFrame = 0;
        CurrFrame = nextFrame;
        return nextFrame;
    }

    public void Reset() => CurrFrame = 0;

    public Vector2 Coord
    {
        get
        {
            return Frames[CurrFrame];
        }
    }

    public List<Vector2> Frames { get; set; }
}

/// <summary>
/// Utility for making & using the spritesheet
/// </summary>
public class SpriteSheet
{
    public Texture2D Texture { get; set; }
    public int Resolution { get; set; } = 32;
    public SpriteSheet(string fp = "spritesheet.png")
    {
        Texture = Raylib.LoadTexture(fp);
    }
}