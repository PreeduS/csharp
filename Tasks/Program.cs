using System;
using System.Threading;
using System.Threading.Tasks;

namespace Tasks
{
    class Program
    {
        static void Main(string[] args)
        {
            
            //var t1 = new Task(() =>{ Thread.Sleep(1000); Console.WriteLine("Task 1"); });
            //t1.Start();

            var source = new CancellationTokenSource();
            var t1 = Task.Factory.StartNew( () => Call(1,4000,"A", source.Token) ).ContinueWith((c) => Call(1,4000,"A2", source.Token) );
            var t2 = Task.Factory.StartNew( () => Call2(2,1000,"B") ).ContinueWith((c) => Call2(2,2000,"B2") ).ContinueWith((c) => Call2(2,3000,"B3") );;


            Console.WriteLine("default");

            //Task.WaitAll(t1, t2);
            //Console.WriteLine("wait all");

            Thread.Sleep(2000);
            source.Cancel();


            Console.ReadKey();
        }


        static void Call(int id, int sleepTime, string type, CancellationToken token){
            if(token.IsCancellationRequested){
                Console.WriteLine("IsCancellationRequested"); return;
            }

            Console.WriteLine($"start {id} {type} {sleepTime}");
            Thread.Sleep(sleepTime);
            Console.WriteLine($"end {id} {type} {sleepTime}");
        }
        static void Call2(int id, int sleepTime, string type){
            Console.WriteLine($"start {id} {type} {sleepTime}");
            Thread.Sleep(sleepTime);
            Console.WriteLine($"end {id} {type} {sleepTime}");
        }

    }
}
