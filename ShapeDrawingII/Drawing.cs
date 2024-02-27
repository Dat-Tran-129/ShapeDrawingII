using SplashKitSDK;

namespace ShapeDrawingII;

public class Drawing
{
    private readonly List<Shape> _shapes;
    private Color _background;
    StreamWriter writer;
    StreamReader reader;

    public Drawing(Color backgroud)
    {
        _shapes = new List<Shape>();
        _background = SplashKit.ColorWhite();
    }

    public Drawing() : this(Color.White)
    {
    }

    public Color Background
    {
        get
        {
            return _background;
        }
        set
        {
            _background = value;
        }
    }

    public int ShapeCount
    {
        get
        {
            return _shapes.Count;
        }
    }

    public List<Shape> SelectedShapes
    {
        get
        {
            List<Shape> result = new List<Shape>();
            foreach (Shape s in _shapes)
            {
                if (s.Selected)
                {
                    result.Add(s);
                }
            }
            return result;
        }
    }

    public void AddShape(Shape s)
    {
        _shapes.Add(s);
    }

    public void Draw()
    {
        SplashKit.ClearScreen(_background);
        foreach (Shape s in _shapes)
        {
            s.Draw(); 
        }
    }
    
    public void ChangingShapeColor()
    {
        foreach (Shape s in _shapes)
        {
            if (s.Selected)
            {
                s.Color = Color.RandomRGB(255);
            }
        }
    }

    public void SelectShapesAt(Point2D pt)
    {
        foreach (Shape s in _shapes)
        {
            if (s.IsAt(pt))
            {
                s.Selected = true;
            }
            else
            {
                s.Selected = false;
            }
        }
    }

    public void RemoveShape(Shape s)
    {
        _shapes.Remove(s);
    }
    
    public void Save(string filename)
    {
        try
        {
            StreamWriter writer = new StreamWriter(filename);
            try
            {
                writer.WriteColor(Background);
                writer.WriteLine(_shapes.Count);
                foreach (Shape s in _shapes)
                {
                    s.SaveTo(writer);
                }
            }
            
            finally
            {
                writer.Close();
            }
            
        }
        catch (Exception e)
        {
            Console.WriteLine("Error during save: " + e.Message);
        }
    }

    public void Load(string filename)
    {
        StreamReader reader =new StreamReader(filename);
        try
        {
            Background = reader.ReadColor();
            int count = reader.ReadInteger();
            _shapes.Clear();
            for (int i = 0; i < count; i++)
            {
                string kind = reader.ReadLine();
                Shape s;
                switch (kind)
                {
                    case "Rectangle":
                        s = new MyRectangle();
                        break;
                    case "Circle":
                        s = new MyCircle();
                        break;
                    case "Line":
                        s = new MyLine();
                        break;
                    default:
                        throw new InvalidDataException("Error at shape: " + kind);
                }

                s.LoadFrom(reader);
                AddShape(s);
            }
        }
        finally
        {
            reader.Close();
        }
    }
}