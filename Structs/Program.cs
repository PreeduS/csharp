using System;

namespace Structs
{
    class Program
    {
        static void Main(string[] args)
        {
            //value type
            //no var initialization
            //no 0 params constructor
            //no class/struct inheritance
            //can be used without new           

            PersonS s = new PersonS("Bob","Boben");
            PersonC c = new PersonC("Bob","Boben");


            Console.WriteLine($"Struct name = {s.Name}");               //Bob
            UpdateS(s);
            Console.WriteLine($"Struct name after change = {s.Name}");  //Bob

            Console.WriteLine();


            Console.WriteLine($"Class name = {c.Name}");                //Bob
            UpdateC(c);
            Console.WriteLine($"Class name after change = {c.Name}");   //Bob edit

            //no constructor
            TestS ts;
            ts.paramA = "A";
            ts.paramB = "B";
      
   
        }

        static void UpdateS(PersonS s){ s.Name = "Bob edit"; }
        static void UpdateC(PersonC c){ c.Name = "Bob edit"; }

        public struct PersonS{
            public string Name;
            public string Lastname;
            public PersonS(string name, string lastname){
                Name = name;
                Lastname = lastname;
            }
        }
        public class PersonC{
            public string Name;
            public string Lastname;
            public PersonC(string name, string lastname){
                Name = name;
                Lastname = lastname;
            }
        }
        public struct TestS{
            public string paramA;
            public string paramB;
        }

    }
}
