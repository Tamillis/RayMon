using Raylib_cs;
using System.Numerics;

namespace RaymonApp;

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

            if (AppData.Debug) Debug.ClearData();

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
                    _render.SetCamTarget(_game.Player.GetPos());
                    _render.DrawTiles(_game.World.Tiles);
                    _render.DrawPlayer(_game.Player);
                    break;
            }

            if (Input.KeyPressed(KeyboardKey.Semicolon)) AppData.Debug = !AppData.Debug;

            //debug data
            if (AppData.Debug)
            {
                Debug.SetData("FPS: " + Raylib.GetFPS().ToString());
                Debug.Draw();
            }

            Raylib.EndDrawing();
        }

        Raylib.CloseWindow();
    }
}