using System.Numerics;
using System.Xml.Linq;
using Raylib_cs;

namespace RaymonApp;

public class Game
{
    private Vector2 _mousePos;  //in world coords
    private Random r = new Random();

    public List<Tile> Tiles = new List<Tile>();
    public List<Entity> Entities = new List<Entity>();
    public Entity Player = new Entity();
    public double Delta { get; set; } = 0;

    public Game()
    {
        //generate world
        for (int y = 0; y < AppData.WorldSize; y++)
        {
            for (int x = 0; x < AppData.WorldSize; x++)
            {
                var tile = new Tile() { Pos = new Vector2(x, y), Col = Color.RayWhite };

                tile.Sprites.Add(SpriteMap.GRASS);
                int n = r.Next(100);
                if (n < 10 && y != 0)
                {
                    tile.Sprites.Add(SpriteMap.TREE_TRUNK);

                    //above tile set to tree top
                    Tiles[(y - 1) * AppData.WorldSize + x].Sprites.Add(SpriteMap.TREE_TOP);
                }

                Tiles.Add(tile);
            }
        }

        //Add player
        Player.Pos = new Vector2(10, 10);
        Player.TargetPos = new Vector2(10, 10);
        Player.Sprite = new Sprite(SpriteMap.PLAYER_FRONT_0);
        Player.Col = Color.White;
    }

    /// <summary>
    /// Returns true if valid position, false otherwise
    /// </summary>
    /// <param name="e"></param>
    public bool IsPosValid(Vector2 pos)
    {
        //TODO: add a collision layer and check that too
        return !(pos.Y < 0 ||
            pos.Y >= AppData.WorldSize ||
            pos.X < 0 ||
            pos.X >= AppData.WorldSize);
    }

    public void Update()
    {
        //Update game logic

        Delta += AppData.Delta;
        if (Delta > 0.25)
        {
            Delta = 0;
            Console.WriteLine("TICK");
            //update game engine tick
            Player.Sprite.NextFrame();
        }

        //manage everything else
        if (Player.State == EntityState.Still)
        {
            if (Input.KeysPressed(KeyboardKey.W, KeyboardKey.Up))
            {
                Player.UpdateTargetPos(new Vector2(0, -1));
                Player.State = EntityState.MovingBackward;
                Player.Sprite = new Sprite(SpriteMap.PLAYER_MOVE_BACK);
            }
            else if (Input.KeysPressed(KeyboardKey.S, KeyboardKey.Down))
            {
                Player.UpdateTargetPos(new Vector2(0, 1));
                Player.State = EntityState.MovingForward;
                Player.Sprite = new Sprite(SpriteMap.PLAYER_MOVE_FRONT);
            }
            else if (Input.KeysPressed(KeyboardKey.A, KeyboardKey.Left))
            {
                Player.UpdateTargetPos(new Vector2(-1, 0));
                Player.State = EntityState.MovingLeft;
                Player.Sprite = new Sprite(SpriteMap.PLAYER_MOVE_LEFT);
            }
            else if (Input.KeysPressed(KeyboardKey.D, KeyboardKey.Right))
            {
                Player.UpdateTargetPos(new Vector2(1, 0));
                Player.State = EntityState.MovingRight;
                Player.Sprite = new Sprite(SpriteMap.PLAYER_MOVE_RIGHT);
            }

            if (!IsPosValid(Player.TargetPos)) Player.TargetPos = Player.Pos;
        }
        else if (Player.State == EntityState.MovingForward ||
            Player.State == EntityState.MovingBackward ||
            Player.State == EntityState.MovingLeft ||
            Player.State == EntityState.MovingRight)
        {
            Player.Move();
        }

        //just debug fun
        if (!AppData.Debug) return;

    }
}
