﻿using SplashKitSDK;

namespace ShapeDrawingII;

public class MyLine : Shape
{
    private int _length;

    public MyLine(Color color, int length) :base(color)
    {
        _length = length;
    }

    public int Length
    {
        get
        {
            return _length;
        }
        set
        {
            _length = value;
        }
    }

    public MyLine() : this(Color.RandomRGB(255), 100) { }

    public override void Draw()
    {
        if (Selected)
        {
            DrawOutline();
        }
        SplashKit.DrawLine(Color, X, Y, X + _length,Y);
    }

    public override void DrawOutline()
    {
        SplashKit.DrawRectangle(Color.Black, X-2, Y-2, _length+5,5);

    }

    public override bool IsAt(Point2D p)
    {
        return SplashKit.PointOnLine(p, SplashKit.LineFrom(X, Y, X + _length,Y));
    }
    
    public override void SaveTo(StreamWriter writer)
    {
        writer.WriteLine("Line");
        base.SaveTo(writer);
        writer.WriteLine(Length);
    }

    public override void LoadFrom(StreamReader reader)
    {
        base.LoadFrom(reader);
        Length = reader.ReadInteger();
    }
    
}