namespace TemplateMethod
{
    public abstract class DataProcessor
    {
        public void ProcessData()
        {
            Load();
            Process();
            Save();
        }
        protected abstract void Load();
        protected virtual void Process()
        {
            Console.WriteLine("Processing Data...");
        }
        protected abstract void Save();
    }

    public class DataBaseProcessor : DataProcessor
    {
        protected override void Load()
        {
            Console.WriteLine("Loading Data from Database...");
        }

        protected override void Save()
        {
            Console.WriteLine("Saving Data to Database...");
        }
    }

    public class FileProcessor:DataProcessor
    {
        protected override void Load()
        {
            Console.WriteLine("Loading Data from File...");
        }

        protected override void Save()
        {
            Console.WriteLine("Saving Data to File...");
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            DataProcessor processor1 = new DataBaseProcessor();
            processor1.ProcessData();
            Console.WriteLine();
            DataProcessor processor2 = new FileProcessor();
            processor2.ProcessData();  
        }
    }
}