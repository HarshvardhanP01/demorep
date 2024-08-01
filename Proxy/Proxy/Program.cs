
namespace Proxy
{
    public interface IImage
    {
        void Display();
    }

    public class RealImage : IImage
    {
        private string? fileName;
        public void Display()
        {
            Console.WriteLine($"Displaying Image : {fileName}.");
        }
        public RealImage(string? fileName)
        {
            this.fileName = fileName;
            LoadImageFromDisk();
        }

        private void LoadImageFromDisk()
        {
            Console.WriteLine($"Loading Image From : {fileName}.");
        }
    }

    public class ProxyImage : IImage
    {
        private RealImage realImage;
        private string? fileName;
        public ProxyImage(string? fileName)
        {
            this.fileName= fileName;
        }
        public void Display()
        {
            if(realImage==null)
            {
                realImage=new RealImage(fileName);
            }
            realImage.Display();
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            IImage img1 = new ProxyImage("img.jpg");
            IImage img2 = new ProxyImage("img2.png");
            img1.Display();
            img1.Display();
            img2.Display();
            img2.Display();
            img1.Display();

        }
    }
}
