using System;

namespace Abstract
{
    class Program
    {
        static void Main(string[] args)
        {
            var b = new Bob("Bob","Boben");
            b.Greet();
            Console.WriteLine(b.GetFullName());

        }
    }

    public abstract class Person{
        private readonly string Firstname, Lastname;

        //no abstract fields allowed, only properties 
        protected abstract int Age{get; set;}

        protected Person(string firstname, string lastname){
            Firstname = firstname;
            Lastname = lastname;
        }

        //An abstract method is implicitly a virtual method.
        public abstract void Greet();
        
        public string GetFullName(){
            return $"{Firstname} {Lastname}";
        }
    }

    public class Bob : Person
    {   
        protected override int Age {get; set;}= 20;
        public Bob(string firstname, string lastname) 
            : base(firstname, lastname){ }

        public override void Greet(){
            Console.WriteLine("Bob says hello...");
        }
    }
}
