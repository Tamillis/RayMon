using Raylib_cs;
using System.Numerics;
using System.Text;


namespace RaymonApp;

public class UIManager
{
    public List<UI_Element> MainMenu { get; set; } = new List<UI_Element>();

    public UIManager()
    {
        //make main menu ui
        MainMenu.Add(new Text("Welcome to Zylen, the island at the end of the lost world.")
        {
            BoundingBox = Utils.GetCenteredRect(AppData.W / 2, AppData.H / 2, 200, 32)
        });

        MainMenu.Add(new Link("Start Game", "GAME_START")
        {
            BoundingBox = Utils.GetCenteredRect(AppData.W / 2, AppData.H / 2 + AppData.FontSize * 4, Raylib.MeasureText("Start Game", AppData.FontSize), AppData.FontSize + 2)
        });
    }

    public void Update()
    {
        if (Raylib.IsMouseButtonPressed(MouseButton.Left))
        {
            var mousePos = Raylib.GetMousePosition();
            foreach (var el in MainMenu)
            {
                //the below is basically what a UI Manager would be doing
                if (!el.IsUnderMouse(mousePos)) continue;

                if (el is Link)
                {
                    string linkRef = ((Link)el).Ref;
                    if (linkRef == "GAME_START") Program.GameState = GameState.Game;
                }
            }
        }
    }
}

public class UI_Element
{
    public Rectangle BoundingBox = new() { X = 0, Y = 0, Width = 0, Height = 0 };
    public bool IsUnderMouse(Vector2 mousePos)
    {
        return mousePos.X > BoundingBox.X &&
            mousePos.X < BoundingBox.X + BoundingBox.Width &&
            mousePos.Y > BoundingBox.Y &&
            mousePos.Y < BoundingBox.Y + BoundingBox.Height;
    }

    public virtual void Draw() 
    {
        if (AppData.Debug) Raylib.DrawRectangleLinesEx(BoundingBox, 1, Color.Red);
    }
}

public class Text : UI_Element
{
    public string Content { get; set; }
    public Font Font { get; set; } = Raylib.GetFontDefault();
    public int FontSize { get; set; } = AppData.FontSize;
    public Color Col { get; set; } = Color.White;

    public Text(string str = "")
    {
        Content = str;
    }

    public override void Draw()
    {
        var wrappedText = WrapText();
        for(int i = 0; i < wrappedText.Count; i++)
        {
            Raylib.DrawText(wrappedText[i], (int)BoundingBox.X, (int)BoundingBox.Y + FontSize * i, FontSize, Col);
        }

        base.Draw();
    }

    public float ContentLength
    {
        get
        {
            return MeasureText(Content);
        }
    }

    public List<string> WrapText()
    {
        int numberOfLines = (int)(ContentLength / BoundingBox.Width) + 1;

        List<string> wrappedText = new List<string>();

        int contentIndex = 0;
        for (int i = 0; i < numberOfLines; i++)
        {
            StringBuilder sb = new StringBuilder();
            while ( MeasureText(sb.ToString()) < BoundingBox.Width && contentIndex < Content.Length)
            {
                sb.Append(Content[contentIndex++]);
            }
            wrappedText.Add(sb.ToString());
        }

        return wrappedText;
    }

    private float MeasureText(string text)
    {
        return Raylib.MeasureTextEx(Font, text, FontSize, 2).X;
    }
}

public class Link : Text
{
    public string Ref { get; set; } = "";

    public Link(string str = "", string @ref = "") : base(str)
    {
        Ref = @ref;
    }

    public override void Draw()
    {
        Col = IsUnderMouse(Raylib.GetMousePosition()) ? Color.Pink : Color.Red;

        base.Draw();
    }
}

public class AnimatedText : Text 
{
    private int _frame;
    private int _totalFrames;
    private string _fullContent;

    private int GetNextFrame()
    {
        _frame++;
        if (_frame >= _totalFrames) _frame = _totalFrames;

        return _frame;
    }

    public AnimatedText(string str = "", int startingFrame = 0) : base(str)
    {
        _frame = startingFrame;
        _totalFrames = Content.Length;
        _fullContent = Content;
    }

    public override void Draw()
    {
        //draw text inside bounding box
    }
}
