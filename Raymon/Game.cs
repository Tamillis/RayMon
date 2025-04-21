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
        var playerPos = new Vector2(10, 10);
        var playerSprite = new Sprite(SpriteMap.PLAYER_FRONT_0);
        Player = new Entity(playerPos, playerSprite);
    }

    /// <summary>
    /// Returns true if valid position, false otherwise. TODO: this is something that should belong to either the entity manager or the world
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

        //input on player
        if (Input.KeysPressed(KeyboardKey.W, KeyboardKey.Up))
        {
            Debug.SetData("KeyPressed W");
            Player.UpdateTargetPos(new Vector2(0, -1));
        }
        else if (Input.KeysPressed(KeyboardKey.S, KeyboardKey.Down))
        {
            Debug.SetData("KeyPressed S");
            Player.UpdateTargetPos(new Vector2(0, 1));
        }
        else if (Input.KeysPressed(KeyboardKey.A, KeyboardKey.Left))
        {
            Debug.SetData("KeyPressed A");
            Player.UpdateTargetPos(new Vector2(-1, 0));
        }
        else if (Input.KeysPressed(KeyboardKey.D, KeyboardKey.Right))
        {
            Debug.SetData("KeyPressed D");
            Player.UpdateTargetPos(new Vector2(1, 0));
        }
        
        Player.Update();

        //move entities
        //TODO: this.
    }

    ///// <summary>
    ///// Moves player by moving target position by delta with given state (i.e. animation to play), if position valid
    ///// </summary>
    //private void UpdatePlayerMoveTarget(Vector2 targetDelta, EntityState newState)
    //{
    //    Player.UpdateTargetPos(targetDelta);
    //    if (!IsPosValid(Player._targetPos))
    //    {
    //        Player._targetPos = Player._pos;

    //        //TODO: this is dumb, do this better
    //        //first change the state to moving in that direction, then still, so its the correct direction of 'still'
    //        Player.UpdateState(newState);
    //        Player.UpdateState(EntityState.Still);
    //    }
    //    else
    //    {
    //        Player.UpdateState(newState);
    //    }
    //}
}
