using System.Numerics;
using Raylib_cs;

namespace RaymonApp;

public class Game
{
    private Vector2 _mousePos;  //in world coords

    public World World = new World();
    public Entity Player = new Entity();
    public double Delta { get; set; } = 0;

    private List<Entity> _entities = new List<Entity>();
    private CollisionHandler _collisionHandler;

    public Game()
    {
        //Add player
        var playerSprite = new Sprite(SpriteMap.PLAYER_FRONT_0);
        Player = new Entity(Vector2.Zero, playerSprite);

        _collisionHandler = new CollisionHandler(World, _entities);
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
        if (Input.MoveKeysPressed())
        {
            Vector2 direction = Vector2.Zero;
            if (Input.KeysPressed(KeyboardKey.W, KeyboardKey.Up))
            {
                Debug.SetData("KeyPressed W");
                direction = new Vector2(0, -1);
            }
            else if (Input.KeysPressed(KeyboardKey.S, KeyboardKey.Down))
            {
                Debug.SetData("KeyPressed S");
                direction = new Vector2(0, 1);
            }
            else if (Input.KeysPressed(KeyboardKey.A, KeyboardKey.Left))
            {
                Debug.SetData("KeyPressed A");
                direction = new Vector2(-1, 0);
            }
            else if (Input.KeysPressed(KeyboardKey.D, KeyboardKey.Right))
            {
                Debug.SetData("KeyPressed D");
                direction = new Vector2(1, 0);
            }
            
            Player.Face(direction);
            Debug.SetData("Direction: " + direction);

            if (!_collisionHandler.Collides(Player.GetPos() + direction))
            {
                Player.UpdateTargetPos(direction);
            }
            else
            {
                Debug.SetData("Player Collides");
            }
        }

        Player.Update();

        //move entities
        //TODO: this.
    }
}
