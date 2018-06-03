using System;
using System.Collections.Generic;
using System.Linq;

//venkat 32 done

namespace Method_Syntax
{
    class Program
    {
        static void Main(string[] args)
        {

            var list = new List<int>(){11,12,1,2,3,4,5,15};

            Console.WriteLine( list.Find(x => x > 3) );

            list.FindAll(x => x > 3).OrderBy(x => x).Take(3).Reverse().ToList().ForEach( x => Console.Write(x+",") );
            //OrderBy().ThenBy()

            
            //select
            Console.WriteLine("\nSelect");
            list.Where(x => x > 3).Select(x => x + 10).ToList().ForEach( x => Console.Write(x +",") );
            list.Select( (el,index) => new {El = el, Index = index} ).ToList().ForEach(x => 
                Console.WriteLine($"El = {x.El}, Index = {x.Index}")
            );

            Console.WriteLine();

            //Aggregate
            Console.WriteLine( list.Aggregate(0, (prev,current) => prev + current ) );
            Console.WriteLine( list.Aggregate<int, string>("acc: ", (prev,current) => prev + ", " + current ) );


        }



    }
}


//.Skip(3) 
//.TakeWhile( ()=>... ) //same as Where but stops at first false
//.SkipWhile( ()=>... ) //skip all until first false 
//.AsEnumerable()		//left query will be executed in sql, right in linq-objects
