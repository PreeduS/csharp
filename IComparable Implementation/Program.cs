using System;
using System.Collections.Generic;

namespace IComparable_Implementation
{
    class Program
    {
        static void Main(string[] args)
        {
           var stuff = new List<Stuff>(){
               new Stuff{ Name = "Name", Size = 10 },
               new Stuff{ Name = "Name2", Size = 5 },
               new Stuff{ Name = "Name3", Size = 15 },
           };

           stuff.Sort();
           stuff.ForEach( s => Console.WriteLine(s.Name) );
        }
    }
    public class Stuff : IComparable<Stuff>{
        public string Name;
        public int Size;

        public int CompareTo(Stuff other){
            return Size - other.Size;
        }

    }
}
