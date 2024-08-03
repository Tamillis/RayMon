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

        //ENGINE - tick and trigger tick-tied game updates
        Delta += AppData.Delta;
        if (Delta > AppData.TickDuration)
        {
            Delta = 0;

            //update game engine tick
            Player.Sprite.NextFrame();
        }

        //move player
        if (Input.KeysPressed(KeyboardKey.W, KeyboardKey.Up))
        {
            Debug.SetData("KeyPressed W");
            UpdatePlayerMoveTarget(new Vector2(0, -1), EntityState.MovingBackward);
        }
        else if (Input.KeysPressed(KeyboardKey.S, KeyboardKey.Down))
        {
            Debug.SetData("KeyPressed S");

            UpdatePlayerMoveTarget(new Vector2(0, 1), EntityState.MovingForward);
        }
        else if (Input.KeysPressed(KeyboardKey.A, KeyboardKey.Left))
        {
            Debug.SetData("KeyPressed A");

            UpdatePlayerMoveTarget(new Vector2(-1, 0), EntityState.MovingLeft);
        }
        else if (Input.KeysPressed(KeyboardKey.D, KeyboardKey.Right))
        {
            Debug.SetData("KeyPressed D");

            UpdatePlayerMoveTarget(new Vector2(1, 0), EntityState.MovingRight);
        }
        Player.Move();

        //move entities
        //TODO: this.
    }

    /// <summary>
    /// Moves player by moving target position by delta with given state (i.e. animation to play), if position valid
    /// </summary>
    /// <param name="targetDelta"></param>
    /// <param name="newState"></param>
    private void UpdatePlayerMoveTarget(Vector2 targetDelta, EntityState newState)
    {
        Player.UpdateTargetJustBefore(targetDelta);
        if (!IsPosValid(Player.TargetPos))
        {
            Player.TargetPos = Player.Pos;

            //first change the state to moving in that direction, then still, so its the correct direction of 'still'
            Player.UpdateState(newState);
            Player.UpdateState(EntityState.Still);
        }
        else
        {
            Player.UpdateState(newState);
        }
    }
}
