using System;
using System.Threading;
using System.Threading.Tasks;

namespace AsyncAwait
{
    class Program
    {
        static void Main(string[] args)
        {
            
            Console.WriteLine("start");
            SomeFuncAsync();
            Console.WriteLine("end");
            

            Console.ReadKey();
        }

        static async void SomeFuncAsync(){

            string result = await GetResultAsync();
            Console.WriteLine("result = " + result);
            
        }
        static Task<string> GetResultAsync(){
            return Task.Factory.StartNew( () =>{
                Thread.Sleep(2000);
                return "test";
            });
        }

    }
}
