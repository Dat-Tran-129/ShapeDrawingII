using SplashKitSDK;

namespace ShapeDrawingII;

public class Program
{
    private enum ShapeKind
    {
        Rectangle,
        Circle,
        Line
    }
    
    public static void Main()
    {
        Drawing myDraw = new Drawing();
        ShapeKind kindToAdd = ShapeKind.Rectangle;
        new Window("Shape Drawer", 800, 600);
        do
        {
            SplashKit.ProcessEvents();
            SplashKit.ClearScreen();
            myDraw.Draw();
            
            if(SplashKit.KeyTyped(KeyCode.RKey))
            {
                kindToAdd = ShapeKind.Rectangle;
            }
            
            if (SplashKit.KeyTyped(KeyCode.LKey))
            {
                kindToAdd = ShapeKind.Line;
            }
            
            if (SplashKit.KeyTyped(KeyCode.CKey))
            {
                kindToAdd = ShapeKind.Circle;
            }
            
            if (SplashKit.MouseClicked(MouseButton.LeftButton))
            {
                if(kindToAdd == ShapeKind.Rectangle)
                {
                    MyRectangle myRect = new MyRectangle();
                    myRect.X = SplashKit.MouseX();
                    myRect.Y = SplashKit.MouseY();
                    myDraw.AddShape(myRect);
                }
                
                if (kindToAdd == ShapeKind.Circle)
                {
                    MyCircle myCir = new MyCircle();
                    myCir.X = SplashKit.MouseX();
                    myCir.Y = SplashKit.MouseY();
                    myDraw.AddShape(myCir);
                }
                
                if (kindToAdd == ShapeKind.Line)
                {
                    MyLine myLn = new MyLine();
                    myLn.X = SplashKit.MouseX();
                    myLn.Y = SplashKit.MouseY();
                    myDraw.AddShape(myLn);
                }
            }
            
            //ChangeBackgroundColor
            if (SplashKit.KeyTyped(KeyCode.SpaceKey))
            {
                myDraw.Background = SplashKit.RandomRGBColor(255);
            }
            
            //SelectShape
            if (SplashKit.MouseClicked(MouseButton.RightButton))
            {
                myDraw.SelectShapesAt(SplashKit.MousePosition());
            }
            
            //ChangeShapeColor
            if (SplashKit.KeyTyped(KeyCode.TabKey))
            {
                myDraw.ChangingShapeColor();
            }
            
            //RemoveShape
            if (SplashKit.KeyTyped(KeyCode.DeleteKey) || SplashKit.KeyTyped(KeyCode.BackspaceKey))
            {
                foreach (Shape s in myDraw.SelectedShapes)
                {
                    myDraw.RemoveShape(s);
                }
            }
            
            //SaveFile
            if (SplashKit.KeyDown(KeyCode.SKey))
            {
                myDraw.Save("/Users/trand/Desktop/Shapes.txt");
            }
            
            //LoadFile
            if (SplashKit.KeyTyped(KeyCode.OKey))
            {
                try
                {
                    myDraw.Load("/Users/trand/Desktop/Shapes.txt");
                } catch(Exception e)
                {
                    Console.Error.WriteLine("Error loading file: {0}", e.Message);
                }
            }
            
            SplashKit.RefreshScreen();
        }
        while(!SplashKit.WindowCloseRequested("Shape Drawer"));
    }
}