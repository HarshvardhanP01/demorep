namespace Adpater
{

    public interface IRoundPin
    {
        //double GetRadius();
        public double Radius { get; }
    }

    public class RoundPin : IRoundPin
    {
        private double _radius;
        public RoundPin(double radius)
        {
            this._radius = radius;
        }

        public double Radius => _radius;
        //public double GetRadius()
        //{
        //    return _radius;
        //}
    }

    public class SquarePin
    {
        private double width;

        public SquarePin(double width)
        {
            this.width = width;
        }
        public double Width => width;
    }

    public class SquarePinAdpater : IRoundPin
    {
        private SquarePin _squarePin;

        public SquarePinAdpater(SquarePin _squarePin)
        {
            this._squarePin = _squarePin;
        }
        public double Radius => _squarePin.Width * Math.Sqrt(2)/2;
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            RoundPin roundPin=new RoundPin(2);
            Console.WriteLine($"Round Pin Radius : {roundPin.Radius}");

            SquarePin _squarePin=new SquarePin(2);
            SquarePinAdpater squarePinAdpater = new SquarePinAdpater(_squarePin);
            Console.WriteLine($"Square Pin Adapter Radius : {squarePinAdpater.Radius}");


        }
    }
}
