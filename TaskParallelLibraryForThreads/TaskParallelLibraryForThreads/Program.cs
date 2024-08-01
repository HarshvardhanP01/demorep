using System.Diagnostics;
using System.Threading.Tasks;


namespace TaskParallelLibraryForThreads
{
    internal class Program
    {
        private static Mutex mutex = new Mutex();
        static void SeqCal(int n)
            {
                int sum = 0;
                for(int i=0;i<=n;i++)
                {
                    sum += i;
                    Task.Delay(10).Wait();
                }
            Console.WriteLine($"Seq:{sum}");
        }
            static void ParaCal(int n)
            {
                int sum = 0;
                Parallel.For(0, n + 1, (n) =>
                {
                    lock (mutex)
                    {
                        sum += n;
                    }
                    Task.Delay(10).Wait();
                });
            Console.WriteLine($"Par:{sum}");
        }
        static void Main(string[] args)
        {

            Stopwatch sw = new Stopwatch();
            sw.Start();
            SeqCal(1000);
            sw.Stop();
            Console.WriteLine($"Time : {sw.ElapsedMilliseconds}");
            sw.Start();
            ParaCal(1000);
            sw.Stop();
            Console.WriteLine($"Time : {sw.ElapsedMilliseconds}");
        }
    }
}
