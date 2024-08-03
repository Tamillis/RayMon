using Raylib_cs;
using System.Numerics;
using System.Xml.Linq;

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

    private double _speedFactor = 2f;

    public void SetSpeedFactor(double d) { _speedFactor = d; }

    /// <summary>
    /// Traversed pixel distance since last frame
    /// </summary>
    public double Traversed
    {
        get => _speedFactor * AppData.EntityBaseSpeed * AppData.Delta;
    }

    //animations should only be reset when state changes
    public void UpdateState(EntityState newState)
    {
        //do nothing is state is already new state
        if (State == newState) return;

        EntityState priorState = State;
        State = newState;

        //state relationships

        //moving to still
        if (State == EntityState.Still && priorState == EntityState.MovingForward)
        {
            Sprite = new Sprite(SpriteMap.PLAYER_FRONT_0);
        }
        else if (State == EntityState.Still && priorState == EntityState.MovingBackward)
        {
            Sprite = new Sprite(SpriteMap.PLAYER_BACK_0);
        }
        else if (State == EntityState.Still && priorState == EntityState.MovingLeft)
        {
            Sprite = new Sprite(SpriteMap.PLAYER_LEFT_0);
        }
        else if (State == EntityState.Still && priorState == EntityState.MovingRight)
        {
            Sprite = new Sprite(SpriteMap.PLAYER_RIGHT_0);
        }

        //new moving state
        else if (State == EntityState.MovingForward)
        {
            Sprite = new Sprite(SpriteMap.PLAYER_MOVE_FRONT);
        }
        else if (State == EntityState.MovingBackward)
        {
            Sprite = new Sprite(SpriteMap.PLAYER_MOVE_BACK);
        }
        else if (State == EntityState.MovingLeft)
        {
            Sprite = new Sprite(SpriteMap.PLAYER_MOVE_LEFT);
        }
        else if (State == EntityState.MovingRight)
        {
            Sprite = new Sprite(SpriteMap.PLAYER_MOVE_RIGHT);
        }
    }

    public void UpdateTargetPos(Vector2 targetDelta)
    {
        TargetPos = Pos + targetDelta;
    }

    /// <summary>
    /// Update the target pos according to the change in target pos given but only if in the next frame it would be reached
    /// </summary>
    public void UpdateTargetJustBefore(Vector2 targetDelta)
    {
        if (AtTargetAfter(Traversed))
        {
            Debug.SetData("UpdateTargetJustBefore - AtTargetAfter(Traversed) : TRUE");

            TargetPos = Pos + targetDelta;
        }
    }

    public bool AtTargetAfter(double delta)
    {
        return Math.Abs(TargetPos.X - Pos.X) < delta && Math.Abs(TargetPos.Y - Pos.Y) < delta;
    }

    public void Move()
    {
        //snap to whole number tile pos once close enough
        if (AtTargetAfter(Traversed))
        {
            Debug.SetData("Move AtTargetAfter(Traversed)");
            Pos = new Vector2(TargetPos.X, TargetPos.Y);
            UpdateState(EntityState.Still);
        }
        else UpdatePos(Traversed);
    }

    //since movement is bound to grid, target pos is in one of the four cardinal directions only
    private void UpdatePos(double dist)
    {
        float newX = Pos.X, newY = Pos.Y;
        switch (State)
        {
            case EntityState.MovingRight:
                newX = Pos.X + (float)dist;
                break;

            case EntityState.MovingLeft:
                newX = Pos.X - (float)dist;
                break;

            case EntityState.MovingForward:
                newY = Pos.Y + (float)dist;
                break;

            case EntityState.MovingBackward:
                newY = Pos.Y - (float)dist;
                break;
        }

        Pos = new Vector2(newX, newY);
    }
}
