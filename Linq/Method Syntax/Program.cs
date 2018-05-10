using System;
using System.Collections.Generic;
using System.Linq;

namespace Method_Syntax
{
    class Program
    {
        static void Main(string[] args)
        {
            //Where
            var list = new List<int>(){1,2,3,4,5};

            Console.WriteLine( list.Find(x => x > 3) );
            
            list.Where(x => x > 3).Select(x => x + 10).ToList().ForEach( x => Console.Write(x +",") );
            
            

        }



    }
}
