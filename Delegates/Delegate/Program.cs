using System;
using System.Collections.Generic;

namespace DelegateEx
{   
    delegate void MeDelegate(int id);

    class Program
    {
        static void Main(string[] args)
        {
            MeDelegate del = Call;
            del(1);
            Wrapper( x => Console.WriteLine(x) );

            //temp  -------------------------------------------------                  
            var testList = Test.SomeList.FilterList( x => x > 3 );

            foreach(var l in testList){
                Console.WriteLine(l);
            }

        }
        static void Wrapper(MeDelegate del){
            del(10);
        }
        static void Call(int id){
           Console.WriteLine(id);
        }

        //predefined delegates:
        //Func<type, type, etc>      //last is the return type, rest ar args
        //Action<type, type, etc>    //all are args, no return type

        //Func<int,bool> f = x => x > 10;
        //Action<int> a = x => Console.WriteLine("a");

    }

    //temp
    public static class Test{
        public static List<int> SomeList;
        static Test(){
            SomeList = new List<int>(){1,2,3,4,5,6};
        }
        public static IEnumerable<T> FilterList<T>(this List<T> list, Func<T, bool> filter){
            foreach(var l in list){  
                if( filter(l) ){
                    yield return l;
                }
            }
        }   

    }
}
