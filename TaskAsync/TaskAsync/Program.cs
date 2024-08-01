using System.Threading.Tasks;
using System.Net.Http;

namespace TaskAsync
{
    internal class Program
    {
            static async Task PerformOperationAsync()
            {
                Console.WriteLine("Starting Async Operation...");
                await Task.Delay(2000);
                Console.WriteLine("Async Opeartion Running...");
                await Task.Delay(2000);
                Console.WriteLine("Async Operation Completed...");
        }
        static async Task<int> CalSum(int n)
        {
            return await Task.Run(() =>
            {
                int sum = 0;
                for (int i = 0; i <= n; i++)
                {
                    sum += i;
                    Task.Delay(100).Wait();
                }
                return sum;
            });
        }
        static async Task<string> FetchDataAsync(string url)
        {
            using (HttpClient client=new HttpClient()) // Heavy Object so go directly to GC when exitn
            {
                HttpResponseMessage response=await client.GetAsync(url);
                response.EnsureSuccessStatusCode();
                string data=await response.Content.ReadAsStringAsync();
                return data;
            }
        }
            static async Task Main(string[] args)
            {
            //Two Ways

            // await PerformOperationAsync();


            /* Task t=PerformOperationAsync();
             * 
             *Restrict Main to wait
         while (!t.IsCompletedSuccessfully)
         {
             Console.Write(".");
             await Task.Delay(500);
         }*/

            //Parallel

            /* int n = 1000;
             int res=await CalSum(n);
             Console.WriteLine($"Sum of Numbers Between 0 to {n} is = {res}");*/


            string? url = "https://jsonplaceholder.typicode.com/todos";
            string? res=await FetchDataAsync(url);
            Console.WriteLine(res);
            Console.WriteLine("Async Call Finished Program Completed");
            Console.ReadKey();
            }

    }
}
