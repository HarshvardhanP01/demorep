namespace Singleton_Pattern
{
    /* public class Singleton
      {
          private static Singleton? instance;
          private static readonly object instanceLock = new object();
          private Singleton()
          {
              Console.WriteLine("New Object Created...");
          }

          public static Singleton GetInstance { 
              get
              {
                  if(instance==null)
                  {
                      lock (instanceLock)
                      {

                         if(instance==null)
                          {

                          instance = new Singleton(); 
                          }
                      }
                  }
                  return instance;
              }
          }
          public void DoSomething()
          {
              Console.WriteLine("Singleton is doing something...");
          }
      }*/

    public class Singleton
    {
        private static readonly Lazy<Singleton> _instance = new Lazy<Singleton>(() => new Singleton());
        private Singleton()
        {
            Console.WriteLine("New Object Created");
        }
        public static Singleton Instance=>_instance.Value;

        public void DoSomething()
        {
            Console.WriteLine("Singleton is doing Something...");
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            /*Singleton singleton = Singleton.GetInstance;
            singleton.DoSomething();
            Console.WriteLine(singleton.GetHashCode());
            Singleton singleton1 = Singleton.GetInstance;
            singleton1.DoSomething();
            Console.WriteLine(singleton1.GetHashCode());

            if(singleton.Equals(singleton1))
            {
                Console.WriteLine(singleton.Equals(singleton1));
            }
            else
            {
                Console.WriteLine("No");
            }*/

            Singleton singleton = Singleton.Instance;
            singleton.DoSomething();
            Console.WriteLine(singleton.GetHashCode());
            Singleton singleton1 = Singleton.Instance;
            singleton1.DoSomething();
            Console.WriteLine(singleton1.GetHashCode());

            if (singleton.Equals(singleton1))
            {
                Console.WriteLine(singleton.Equals(singleton1));
            }
            else
            {
                Console.WriteLine("No");
            }
        }
    }
}
