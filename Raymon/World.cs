using Raylib_cs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace RaymonApp;

public class World
{
    public List<Tile> Tiles = new List<Tile>();

    public World()
    {
        Random r = new Random();

        //generate world - TODO: replace this with custom made maps from a file, file loading etc.
        for (int y = 0; y < AppData.WorldSize; y++)
        {
            for (int x = 0; x < AppData.WorldSize; x++)
            {
                var tile = new Tile() { Pos = new Vector2(x, y), Col = Color.RayWhite };

                tile.Sprites.Add(SpriteMap.GRASS);
                int n = r.Next(100);
                if (n < 10 && y != 0 && x != 0)
                {
                    tile.Sprites.Add(SpriteMap.TREE_TRUNK);
                    tile.Collidable = true;
                    //above tile set to tree top
                    Tiles[(y - 1) * AppData.WorldSize + x].Sprites.Add(SpriteMap.TREE_TOP);
                    Tiles[(y - 1) * AppData.WorldSize + x].Collidable = true;
                }

                Tiles.Add(tile);
            }
        }
    }
}
