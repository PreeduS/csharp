using System;

namespace Tuple
{
    class Program
    {
        static void Main(string[] args)
        {
           
            (int, int, double) SomeTuple(int value){
                var r = (0, 10, 20.0);
                r.Item3 += value;
                return r;
            }
            
            (int sum, int count) SomeTuple2(params int[] p){
                var r = (s: 0, c: 0);
                
                foreach(var el in p){
                    r.s += el;
                    r.c++;
                }
                return r;
            }


            var t = SomeTuple(5);
            Console.WriteLine($"{t.Item1}, {t.Item2}, {t.Item3}");

            var t2 = SomeTuple2(10,20,30);
            Console.WriteLine($"{t2.sum}, {t2.count}");

            var (sum, count) = SomeTuple2(1,2,3,4);
            Console.WriteLine($"{sum}, {count}");
        }
    }
}
