namespace Bridge
{
    public interface IDrawingAPI
    {
        void DrawCircle(double x,double y,double r);
        void DrawSquare(double x,double y,double side);
    }

    public class ScreenDrawingAPI : IDrawingAPI
    {
        public void DrawCircle(double x, double y, double r)
        {
            Console.WriteLine($"Drawing circle on screen at {x},{y} with radius : {r}");
        }

        public void DrawSquare(double x, double y, double side)
        {
            Console.WriteLine($"Drawing square on screen at {x},{y} with side : {side}");

        }
    }

    public class PrinterDrawingAPI : IDrawingAPI
    {
        public void DrawCircle(double x, double y, double r)
        {
            Console.WriteLine($"Printing circle on screen at {x},{y} with radius : {r}");
        }

        public void DrawSquare(double x, double y, double side)
        {
            Console.WriteLine($"Printing square on screen at {x},{y} with side : {side}");

        }
    }

    public abstract class Shape
    {
        protected IDrawingAPI _drawingAPI;

        protected Shape(IDrawingAPI _drawingAPI)
        {
            this._drawingAPI = _drawingAPI;
        }
        public abstract void Draw();
        public abstract void Resize(double factor);
    }

    public class Circle : Shape
    {
        private double x, y, r;
        public Circle(double x, double y, double r, IDrawingAPI _drawingAPI) : base(_drawingAPI)
        {
            this.x = x;
            this.y = y;
            this.r = r;
        }
        public override void Draw()
        {
            _drawingAPI.DrawCircle(x, y, r);
        }

        public override void Resize(double factor)
        {
            r *= factor;
        }
    }
    public class Square : Shape
    {
        private double x, y, s;
        public Square(double x, double y, double s, IDrawingAPI _drawingAPI) : base(_drawingAPI)
        {
            this.x = x;
            this.y = y;
            this.s = s;
        }
        public override void Draw()
        {
            _drawingAPI.DrawSquare(x, y, s);
        }

        public override void Resize(double factor)
        {
            s *= factor;
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
           IDrawingAPI screenAPI=new ScreenDrawingAPI();
           IDrawingAPI printerAPI=new PrinterDrawingAPI();
           Shape circle = new Circle(2,2,2,screenAPI);
            Shape square= new Square(2,2,2,printerAPI);
            circle.Draw();
            circle.Resize(2);
            circle.Draw();
            square.Draw();
            square.Resize(2);
            square.Draw();
        }
    }
}
