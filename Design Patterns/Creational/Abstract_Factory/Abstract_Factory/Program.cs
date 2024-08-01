namespace Abstract_Factory
{
    public interface IChair
    {
        void SitOn();
    }

    public interface ISofa
    {
        void LieON();
    }

    public class GardernChair: IChair
    {
        public void SitOn()
        {
            Console.WriteLine("Sitting on a garden chair.");
        }
    }

    public class GardenSofa : ISofa
    {
        public void LieON()
        {
            Console.WriteLine("Lying on Garden Sofa");
        }
    }

    public class OfficeChair : IChair
    {
        public void SitOn()
        {
            Console.WriteLine("Sitting on an Office chair.");
        }
    }

    public class OfficeSofa : ISofa
    {
        public void LieON()
        {
            Console.WriteLine("Lying on Office Sofa");
        }
    }

    public interface IFurnitureFactory
    {
        IChair createChair();
        ISofa createSofa();
    }

    public class GardenFurnitureFactory : IFurnitureFactory
    {
        public IChair createChair()
        {
            return new GardernChair();
        }

        public ISofa createSofa()
        {
            return new GardenSofa();
        }
    }

    public class OfficeFurnitureFactory : IFurnitureFactory
    {
        public IChair createChair()
        {
           return new OfficeChair();
        }

        public ISofa createSofa()
        {
           return new OfficeSofa();
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            IFurnitureFactory gfurnitureFactory=new GardenFurnitureFactory();
            IChair chair=gfurnitureFactory.createChair();
            ISofa sofa=gfurnitureFactory.createSofa();
            chair.SitOn();
            sofa.LieON();

            IFurnitureFactory ofurnitureFactory = new OfficeFurnitureFactory();
            IChair chair1=ofurnitureFactory.createChair();
            ISofa sofa1=ofurnitureFactory.createSofa();
            chair1.SitOn();
            sofa1.LieON();

        }
    }
}
