namespace Observer
{
    public interface IObserver
    {
        void Update(float temprature);
    }

    public interface ISubject
    {
        void RegisterObserver(IObserver observer);
        void DeRegisterObserver(IObserver observer);
        void NotifyObserver();
    }

    public class WeatherStation : ISubject
    {
        private readonly List<IObserver> _observers;
        private float _temprature;
        public WeatherStation()
        {
            this._observers= new List<IObserver>();
        }
        public void DeRegisterObserver(IObserver observer)
        {
           _observers.Remove(observer);
        }

        public void NotifyObserver()
        {
            foreach(IObserver observer in this._observers)
            {
                observer.Update(this._temprature);
            }
        }

        public void RegisterObserver(IObserver observer)
        {
           _observers.Add(observer);
        }

        public void Settemprature(float temp)
        {
            _temprature = temp;
            NotifyObserver();
        }
    }



    public class TempratureDisplay : IObserver
    {
        private float _temprature;
        public void Update(float temprature)
        {
            this._temprature = temprature;
            Display();
        }
        public void Display()
        {
            Console.WriteLine($"Current Temp :{_temprature}");
        }
    }

    public class AnotherDisplay : IObserver
    {
        private float _temprature;
        public void Update(float temprature)
        {
            this._temprature = temprature;
            Display();
        }
        public void Display()
        {
            Console.WriteLine($"Another : Current Temp :{_temprature}");
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            WeatherStation weatherStation = new WeatherStation();
            TempratureDisplay tempratureDisplay = new TempratureDisplay();
            AnotherDisplay anotherDisplay = new AnotherDisplay();
            weatherStation.RegisterObserver(tempratureDisplay);
            weatherStation.RegisterObserver(anotherDisplay);
            weatherStation.Settemprature(21.13f);
            weatherStation.Settemprature(32.71f);
            weatherStation.DeRegisterObserver(tempratureDisplay);
            weatherStation.Settemprature(45.23f);
        }
    }
}
