using Raylib_cs;
using System.Numerics;

namespace RaymonApp;

public enum EntityState
{
    Still,
    MovingForward,
    MovingLeft,
    MovingBackward,
    MovingRight
}

public class Entity
{
    public Sprite Sprite { get; set; }
    public Vector2 Pos { get; set; }
    public Color Col { get; set; }
    public Vector2 TargetPos { get; set; }
    public EntityState State { get; set; } = EntityState.Still;

    private float _speed = 2f;

    public void UpdateTargetPos(Vector2 targetDelta)
    {
        TargetPos = Pos + targetDelta;
    }

    public void SetTargetPos(Vector2 targetPos)
    {
        TargetPos = targetPos;
    }

    public void Move()
    {
        //snap to whole number tile pos once close enough
        float relSpeed = (float)(Convert.ToDouble(_speed) * AppData.Delta);
        if (Math.Abs(TargetPos.X - Pos.X) < relSpeed && Math.Abs(TargetPos.Y - Pos.Y) < relSpeed)
        {
            Pos = new Vector2(TargetPos.X, TargetPos.Y);

            //this state management code should be somewhere more sensible
            if (State == EntityState.MovingForward)
            {
                Sprite = new Sprite(SpriteMap.PLAYER_FRONT_0);
            }
            else if (State == EntityState.MovingBackward)
            {
                Sprite = new Sprite(SpriteMap.PLAYER_BACK_0);
            }
            else if (State == EntityState.MovingLeft)
            {
                Sprite = new Sprite(SpriteMap.PLAYER_LEFT_0);
            }
            else if (State == EntityState.MovingRight)
            {
                Sprite = new Sprite(SpriteMap.PLAYER_RIGHT_0);
            }
            State = EntityState.Still;
        }
        else
        {
            float newX = Pos.X, newY = Pos.Y;
            if (Pos.X < TargetPos.X)
            {
                newX = Pos.X + relSpeed;
            }
            else if (Pos.X > TargetPos.X)
            {
                newX = Pos.X - relSpeed;
            }
            else if (Pos.Y < TargetPos.Y)
            {
                newY = Pos.Y + relSpeed;

            }
            else if (Pos.Y > TargetPos.Y)
            {
                newY = Pos.Y - relSpeed;
            }

            Pos = new Vector2(newX, newY);
        }
    }
}
