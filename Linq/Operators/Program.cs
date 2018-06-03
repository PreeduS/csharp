using System;
using System.Collections.Generic;
using System.Linq;

namespace Operators
{
    class Program
    {
        static void Main(string[] args)
        {
            var list = new List<int>{1,2,3,4,5};

            Console.WriteLine( list.First() );
            //Console.WriteLine( list.First(x => x > 5) );    //err
            Console.WriteLine( list.FirstOrDefault() );   
            Console.WriteLine( list.FirstOrDefault(x => x > 5) );    //0

            //Console.WriteLine( list.ElementAt(5) );             //err 
            Console.WriteLine( list.ElementAtOrDefault(5) );    //0  

            //.Last();
            //.LastOrDefault();
            //.Single();
            //.SingleOrDefault();   //throws an exception only if
                                    //more than one element satisfies the condition; default value if not found

            list.DefaultIfEmpty().ToList().ForEach( x => Console.Write( x + " ") ); //1 2 3 4 5
            Console.WriteLine();
            list = new List<int>{};
            list.DefaultIfEmpty().ToList().ForEach( x => Console.Write( x + " ") ); //0
            list.DefaultIfEmpty(100).ToList().ForEach( x => Console.Write( x + " ") ); //100

            Console.WriteLine();
            var list2 = new List<string>{"aaa","AAA","bbb","ccc"};
            list2.Distinct(StringComparer.OrdinalIgnoreCase).ToList().ForEach( x => Console.Write(x + ",") );

            var list3 = new List<Item>{
                new Item{Id = 1, Name = "Item 1"},
                new Item{Id = 2, Name = "Item 2"},
                new Item{Id = 2, Name = "Item 2"},
                new Item{Id = 3, Name = "Item 2"}
            };
            Console.WriteLine("Distinct:");
            list3.Distinct(new ItemComparer()).ToList().ForEach( x => Console.WriteLine($"Id: {x.Id}, Name: {x.Name}") );


            var list4 = new List<Item>{
                new Item{Id = 1, Name = "Item 1"},
                new Item{Id = 4, Name = "Item 4"}
            };
            Console.WriteLine("Union:");
            list3.Union(list4, new ItemComparer()).ToList().ForEach( x => Console.WriteLine($"Id: {x.Id}, Name: {x.Name}")  );
        
            Console.WriteLine("Distinct:");
            list3.Distinct(new ItemComparer()).ToList().ForEach( x => Console.WriteLine($"Id: {x.Id}, Name: {x.Name}")  );
        
            Console.WriteLine("Range:");
            Enumerable.Range(1,10).Where(x => x % 2 == 0).ToList().ForEach( x => Console.Write(x + ","));

            Console.WriteLine("\nConcat:");    
            new List<int>{1,2,3}.Concat(new List<int>{1,4,5}).ToList().ForEach( x => Console.Write(x + ","));

            Console.WriteLine();
            Console.WriteLine("All: " +  new List<int>{1,2,3}.All( x => x < 3 ) );
            Console.WriteLine("Any: " +  new List<int>{1,2,3}.Any( x => x < 3 ) );

            Console.WriteLine("Contains: " +  new List<int>{1,2,3}.Contains(5) );

            Console.WriteLine("Contains: " +  new List<Item>{
                new Item{Id = 1, Name = "Item 1"},
                new Item{Id = 2, Name = "Item 2"},
            }.Contains(new Item{Id = 1, Name = "Item 1"}, new ItemComparer()) );

        }
    }

    public class Item{
        public int Id;
        public string Name;
    }

    public class ItemComparer : IEqualityComparer<Item>
    {
        public bool Equals(Item x, Item y)
        {
            return x.Id == y.Id && x.Name == y.Name;
        }

        public int GetHashCode(Item obj)
        {
            return obj.Id.GetHashCode() ^ obj.Name.GetHashCode();
        }
    }
}
