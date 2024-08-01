using System.Threading.Tasks;

namespace TaskParallel
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var nums = Enumerable.Range(1, 10000);
            var evennum=from n in nums.AsParallel().WithDegreeOfParallelism(Environment.ProcessorCount) where n % 2 == 0 select n;
            foreach (var n in evennum)
            {
                Console.WriteLine(n);
            }
            Console.ReadKey();
        }
    }
}
