namespace Statergy
{
    public class Order
    {
        public double Weight { get; set; }
        private readonly IShippingStatergy shippingStatergy;
        public Order(IShippingStatergy shippingStatergy)
        {
            this.shippingStatergy = shippingStatergy;
        }

        public double CalculateShippingCost()
        {
            return shippingStatergy.CalculateShippingCost(this);
        }
    }
    public interface IShippingStatergy
    {
        double CalculateShippingCost(Order order);
    }

    public class StandardShippingStatergy : IShippingStatergy
    {
        public double CalculateShippingCost(Order order)
        {
            return order.Weight * 0.1; 
        }
    }

    public class ExpressShippingStatergy : IShippingStatergy
    {
        public double CalculateShippingCost(Order order)
        {
            return order.Weight * 0.2;
        }
    }

    public class FreeShippingStatergy : IShippingStatergy
    {
        public double CalculateShippingCost(Order order)
        {
            return 0;
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Order order = new Order(new FreeShippingStatergy())
            {
                Weight = 100
            };

            Console.WriteLine($"Freeshipping cost is : {order.CalculateShippingCost()}");


            Order order1 = new Order(new StandardShippingStatergy())
            {
                Weight = 100
            };

            Console.WriteLine($"Standardshipping cost is : {order1.CalculateShippingCost()}");

            Order order2 = new Order(new ExpressShippingStatergy())
            {
                Weight = 100
            };

            Console.WriteLine($"Expressshipping cost is : {order2.CalculateShippingCost()}");

        }
    }
}

