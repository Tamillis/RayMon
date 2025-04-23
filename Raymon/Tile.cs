using System.Numerics;
using Raylib_cs;

namespace RaymonApp;

public class Tile
{
    public List<Vector2> Sprites { get; set; } = new List<Vector2>();
    public Vector2 Pos { get; set; } = Vector2.Zero;
    public Color Col { get; set; } = Color.White;
    public bool Collidable { get; set; } = false;
}
