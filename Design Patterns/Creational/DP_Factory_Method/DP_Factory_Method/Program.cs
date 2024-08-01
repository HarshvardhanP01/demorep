namespace DP_Factory_Method
{
    public interface IVehicle
    {
        void Drive();
    }

    public class Car : IVehicle
    {
        public void Drive()
        {
            Console.WriteLine("Driving A Car");
        }
    }

    public class Truck : IVehicle
    {
        public void Drive()
        {
            Console.WriteLine("Driving A Truck");
        }
    }

    public class Bus : IVehicle
    {
        public void Drive()
        {
            Console.WriteLine("Driving A Bus");
        }
    }

    public static class VehicleFactory
    {
        public static IVehicle? CreateVehicle(string? vehicleType)
        {
            if(string.IsNullOrEmpty(vehicleType))
            {
                return null;
            }
            switch(vehicleType.ToLower())
            {
                case "truck":
                    return new Truck();
                case "car":
                    return new Car();
                case "bus":
                    return new Bus();

                default:
                    throw new InvalidOperationException("Invalid Vehicle Type Requested.");
            }
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            IVehicle? vehicle = VehicleFactory.CreateVehicle("CAR");
            vehicle?.Drive();
            IVehicle? vehicle1 = VehicleFactory.CreateVehicle("BuS");
            vehicle1?.Drive();
            IVehicle? vehicle2 = VehicleFactory.CreateVehicle("TrucK");
            vehicle2?.Drive();
            try
            {
                IVehicle? vehicle3 = VehicleFactory.CreateVehicle("Bike");
                vehicle3?.Drive();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.ReadKey();
        }
    }
}
