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
    public Entity() {
        Sprite = new Sprite(new Vector2(0,0));
        Col = Color.White;
    }

    public Entity(Vector2 pos, Sprite sprite) 
    {
        _pos = pos;
        _targetPos = pos;
        Sprite = sprite;
        Col = Color.White;
    }

    private Vector2 _pos { get; set; } = new Vector2(0, 0);
    private Vector2 _targetPos { get; set; } = new Vector2(0, 0);
    private EntityState State { get; set; } = EntityState.Still;

    private double _speedFactor = 2f;
    public Sprite Sprite { get; set; }
    public Color Col { get; set; }

    public void SetSpeedFactor(double d) { _speedFactor = d; }

    //animations should only be reset when state changes
    public void UpdateState(EntityState newState)
    {
        //do nothing is state is already new state
        if (State == newState) return;

        EntityState priorState = State;
        State = newState;

        //state relationships

        // Sprite determination should be done by the renderer no?

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
        if (!AtTarget()) return;

        _targetPos = new Vector2((float)Math.Round(_pos.X + targetDelta.X), (float)Math.Round(_pos.Y + targetDelta.Y));

        //derive state by target pos diff
        if (_targetPos.X - _pos.X == 1) UpdateState(EntityState.MovingRight);
        else if (_targetPos.X - _pos.X == -1) UpdateState(EntityState.MovingLeft);
        else if (_targetPos.Y - _pos.Y == 1) UpdateState(EntityState.MovingForward);
        else if (_targetPos.Y - _pos.Y == -1) UpdateState(EntityState.MovingBackward);
        else Debug.SetData("You fucked up the target pos: " + _targetPos);
    }

    public Vector2 GetPos()
    {
        return _pos;
    }

    public void Update()
    {
        //check if Pos is at, or near enough, to target
        if (AtTarget())
        {
            _pos = _targetPos;
            UpdateState(EntityState.Still);
        }
        else
        {
            Move();
        }

        Debug.SetData("Pos: " + _pos);
        Debug.SetData("TargetPos: " + _targetPos);
        Debug.SetData("Player State: " + State);
    }

    public bool AtTarget()
    {
        switch(State)
        {
            case EntityState.MovingBackward:
                    return _targetPos.Y >= _pos.Y;
            case EntityState.MovingForward:
                return _targetPos.Y <= _pos.Y;
            case EntityState.MovingLeft:
                return _targetPos.X >= _pos.X;
            case EntityState.MovingRight:
                return _targetPos.X <= _pos.X;
            default:
                return true;
        }
    }

    /// <summary>
    /// since movement is bound to grid, target pos is in one of the four cardinal directions only
    /// </summary>
    private void Move()
    {
        float newX = _pos.X, newY = _pos.Y;
        switch (State)
        {
            case EntityState.MovingRight:
                newX = _pos.X + (float)MoveDist;
                break;

            case EntityState.MovingLeft:
                newX = _pos.X - (float)MoveDist;
                break;

            case EntityState.MovingForward:
                newY = _pos.Y + (float)MoveDist;
                break;

            case EntityState.MovingBackward:
                newY = _pos.Y - (float)MoveDist;
                break;
        }

        _pos = new Vector2(newX, newY);
    }

    private double MoveDist => _speedFactor * AppData.EntityBaseSpeed * AppData.Delta;
}
