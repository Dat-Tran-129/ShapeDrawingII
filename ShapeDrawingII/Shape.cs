﻿using SplashKitSDK;

namespace ShapeDrawingII;

public abstract class Shape
{
    private Color _color;
    private float _x, _y;
    private int _width, _height;
    private bool _selected;

    public Shape(Color clr)
    {
        _color = clr;
    }
    
    public Color Color
    {
        get
        {
            return _color;
        }
        set
        {
            _color = value;
        }
    }

    public float X
    {
        get
        {
            return _x;
        }
        set
        {
            _x = value;
        }
    }

    public float Y
    {
        get
        {
            return _y;
        }
        set
        {
            _y = value;
        }
    }

    public int Width
    {
        get
        {
            return _width;
        }
        set
        {
            _width = value;
        }
    }

    public int Height 
    {
        get
        {
            return _height;
        }
        set
        {
            _height = value;
        }
    }

    public bool Selected
    {
        get 
        {
            return _selected;
        }
        set
        {
            _selected = value;
        }
    }

    public abstract void Draw();

    public abstract bool IsAt(Point2D pt);
    
    public abstract void DrawOutline();
    
    public virtual void SaveTo(StreamWriter writer)
    {
        writer.WriteColor(_color);
        writer.WriteLine(X);
        writer.WriteLine(Y);
    }

    public virtual void LoadFrom(StreamReader reader)
    {
        _color = reader.ReadColor();
        X = reader.ReadInteger();
        Y = reader.ReadInteger();
    }

}