using Raylib_cs;
using System.Numerics;

namespace RaymonApp;

public static class AppData
{
    public static readonly int W = 32 * 32;
    public static readonly int H = 24 * 32;
    public static readonly int WorldSize = 100;
    public static readonly int FontSize = 16;
    public static readonly int DebugFontSize = 16;
    public static bool Debug = true;
    public static double Delta = 0f;

    public static readonly int SpriteScale = 32;
}

public enum GameState
{
    MainMenu,
    Game
}

public class Program
{
    public static GameState GameState { get; set; } = GameState.MainMenu;

    //UI
    private static UIManager _ui;

    //Game instance
    private static Game _game;

    // Renderer
    private static Render _render;

    static void Main()
    {
        Raylib.InitWindow(AppData.W, AppData.H, "Raymon");

        _game = new Game();
        _render = new Render();
        _ui = new UIManager();

        while (!Raylib.WindowShouldClose())
        {
            Raylib.BeginDrawing();

            AppData.Delta = Raylib.GetFrameTime();

            //basic state management
            switch (GameState)
            {
                case GameState.MainMenu:
                    Raylib.ClearBackground(Color.DarkGray);
                    _ui.Update();

                    _render.DrawUI(_ui.MainMenu);
                    break;
                case GameState.Game:
                    Raylib.ClearBackground(Color.SkyBlue);

                    _game.Update();
                    _render.SetCamTarget(_game.Player.Pos);
                    _render.DrawTiles(_game.Tiles);
                    _render.DrawPlayer(_game.Player);
                    break;
            }

            if (Input.KeyPressed(KeyboardKey.Semicolon)) AppData.Debug = !AppData.Debug;

            //debug data
            if (AppData.Debug)
            {
                List<string> debugData = new() { 
                    "FPS: " + Raylib.GetFPS().ToString(), 
                    "TargetPos: " + _game.Player.TargetPos,
                    "Player State: " + _game.Player.State
                };
                DrawDebug(debugData);
            }

            Raylib.EndDrawing();
        }

        Raylib.CloseWindow();
    }

    private static void DrawDebug(List<string> debugData)
    {
        int debugWidth = debugData.Select(str => Raylib.MeasureText(str, AppData.DebugFontSize)).Max();
        Raylib.DrawRectangle(0, 0, debugWidth, AppData.DebugFontSize * (debugData.Count + 1), Color.Black);
        Raylib.DrawText("Debug:", 0, 0, AppData.DebugFontSize, Color.White);
        for (int i = 0; i < debugData.Count; i++)
        {
            Raylib.DrawText(debugData[i], 0, AppData.DebugFontSize * (i + 1), AppData.DebugFontSize, Color.White);
        }
    }
}