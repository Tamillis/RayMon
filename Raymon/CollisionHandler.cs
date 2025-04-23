using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace RaymonApp;

public class CollisionHandler
{
    private World _world;
    private List<Entity> _entities;
    public CollisionHandler(World world, List<Entity> entities)
    {
        _world = world;
        _entities = entities;
    }

    public bool Collides(Vector2 loc)
    {
        //out of bounds
        if (loc.X < 0 || loc.X >= AppData.WorldSize) return true;
        if (loc.Y < 0 || loc.Y >= AppData.WorldSize) return true;

        // collidable world tile
        foreach (var tile in _world.Tiles)
        {
            if (loc == tile.Pos && tile.Collidable) return true;
        }

        // occupied by other entity
        foreach (var entity in _entities)
        {
            if (entity.Collides(loc)) return true;
        }

        return false;
    }
}
