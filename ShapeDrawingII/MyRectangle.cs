﻿using SplashKitSDK;

namespace ShapeDrawingII;

public class MyRectangle : Shape
{
    private int _width;
    private int _height;
    
    public MyRectangle(Color clr, float x, float y, int width, int height) : base(clr)
    {
        X = x;
        Y = y;
        Width = width;
        Height = height;
    }
   
    public MyRectangle() : this(Color.RandomRGB(255), 0, 0, 100, 100)
    {
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
           
    public override void Draw()
    {
        if (Selected)
        {
            DrawOutline();
        }
        SplashKit.FillRectangle(Color, X, Y, Width, Height);
    }
           
    public override void DrawOutline()
    {
        SplashKit.FillRectangle(Color.Black, X - 2, Y - 2, _width + 4, _height + 4);
    }
   
    public override bool IsAt(Point2D p)
    {
        return SplashKit.PointInRectangle(p, SplashKit.RectangleFrom(X, Y, Width, Height));
    }
    
    public override void SaveTo(StreamWriter writer)
    {
        writer.WriteLine("Rectangle");
        base.SaveTo(writer);
        writer.WriteLine(Width);
        writer.WriteLine(Height);
    }

    public override void LoadFrom(StreamReader reader)
    {
        base.LoadFrom(reader);
        Width = reader.ReadInteger();
        Height = reader.ReadInteger();
    }
}