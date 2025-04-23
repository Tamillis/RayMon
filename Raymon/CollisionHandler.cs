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
        foreach (var tile in _world.Tiles)
        {
            if (loc == tile.Pos && tile.Collidable) return true;
        }

        foreach (var entity in _entities)
        {
            if (entity.Collides(loc)) return true;
        }

        return false;
    }
}
