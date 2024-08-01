using System.Threading;

namespace MultiThreading
{
    internal class Program
    {
        private static int counter = 0;
      //  private static readonly object subject=new object(); // Within Same App
     // private static Mutex mutex=new Mutex();// Scope Beyond App. so work with other app too.
         private static SemaphoreSlim semaphoreSlim=new SemaphoreSlim(1,2);
        static void IncrementCounter()
        {
          for(int i=0;i<1000;i++)
            {
                /*lock (subject)
                {
                    counter++; 
                }*/

                /* Monitor.Enter(subject);
                 try
                 {
                     counter++;
                 }
                 finally
                 {
                     Monitor.Exit(subject);
                 }*/

                /* if(mutex.WaitOne())
                     try
                     {
                         counter++;
                     }
                     finally 
                     { 
                         mutex.ReleaseMutex();
                     }*/

                semaphoreSlim.Wait();
                {
                    try
                    {
                        counter++;
                    }
                    finally { semaphoreSlim.Release(); }
                }
                Thread.Sleep(10);
            }
        }
        static void Main(string[] args)
        {

            Thread t1= new Thread(IncrementCounter);
            Thread t2 = new Thread(IncrementCounter); 
            t1.Start();
            t2.Start();
            t1.Join();
            t2.Join();

            Console.WriteLine($"Final Counter Value : {counter}");
        }
    }
}
