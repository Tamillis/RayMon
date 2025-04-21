using Raylib_cs;
using System.Numerics;
using System.Xml.Linq;

namespace RaymonApp;

public class Render
{
    private Vector2 _camPos = new Vector2(0, 0);
    private float _scale = 32;
    private SpriteSheet _tileSpriteSheet = new SpriteSheet();
    private SpriteSheet _playerSpriteSheet = new SpriteSheet("playerSprite.png");

    public Render() { }

    /// <summary>
    /// Set camera target in world-coords
    /// </summary>
    public void SetCamTarget(Vector2 target)
    {
        //can do logic to smooth it and stuff
        _camPos = target - new Vector2((AppData.W / _scale) / 2, (AppData.H / _scale) / 2);
    }

    public void DrawUI(List<UI_Element> uiElements)
    {
        foreach (var ui in uiElements) ui.Draw();
    }

    public void DrawTiles(List<Tile> tiles)
    {
        var mp = GetWorldPos(Raylib.GetMousePosition());

        foreach (var tile in tiles)
        {
            Vector2 screenPos = GetScreenPos(tile.Pos);

            foreach (var sprite in tile.Sprites)
            {

                if (AppData.Debug && mp == tile.Pos)
                {
                    DrawSprite(screenPos, sprite, _tileSpriteSheet, Color.Red);
                }
                else DrawSprite(screenPos, sprite, _tileSpriteSheet, tile.Col);
            }
        }
    }

    public void DrawPlayer(Entity player)
    {
        Vector2 screenPos = GetScreenPos(player.GetPos());

        DrawSprite(screenPos, player.Sprite.Coord, _playerSpriteSheet, player.Col);
        
    }

    public void DrawSprite(Vector2 pos, Vector2 sprite, SpriteSheet? sheet = null)
    {
        DrawSprite(pos, sprite, sheet ?? _tileSpriteSheet, Color.White);
    }

    public void DrawSprite(Vector2 pos, Vector2 sprite, SpriteSheet sheet, Color tint)
    {
        var frameRectangle = new Rectangle(sprite.X * sheet.Resolution, sprite.Y * sheet.Resolution, sheet.Resolution, sheet.Resolution);
        Raylib.DrawTextureRec(sheet.Texture, frameRectangle, pos, tint);
    }

    private Vector2 GetScreenPos(Vector2 worldPos)
    {
        return (worldPos - _camPos) * _scale;
    }

    private Vector2 GetWorldPos(Vector2 screenPos)
    {
        var pos = (screenPos / _scale) + _camPos;
        return new Vector2((int)pos.X, (int)pos.Y);
    }
}
