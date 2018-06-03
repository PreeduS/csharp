using System;

namespace Interface
{
    class Program
    {
        static void Main(string[] args)
        {
            new Person().Greet();
        }
    }

    interface IPerson{
        //no fields, no access specifiers(defaults to public), no static
        string name{get; set;}
        void Greet();
    }
    class Person : IPerson{
        public string name{get; set;} = "Test";
        public void Greet(){
            Console.WriteLine("Hello");
        }
    }
}
