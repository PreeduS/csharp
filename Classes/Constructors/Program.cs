using System;

namespace Constructors
{
    class Program
    {
        static void Main(string[] args)
        {
            var sc1 = new SomeClass();
            var sc2 = new SomeClass("v1");
            var sc3 = new SomeClass("a","b","c");

            Console.WriteLine(sc1.ToString());
            Console.WriteLine(sc2.ToString());
            Console.WriteLine(sc3.ToString());
            
            Console.ReadKey();
        }
    }

    public class SomeClass : SomeParrentClass{
        public string var1 {get; set;}
        public string var2 {get; set;}
        public string var3 {get; set;}

        public SomeClass(string v1, string v2, string v3) : base("base"){
            var1 = v1;
            var2 = v2;
            var3 = v3;
        }
        public SomeClass(string v1) 
            : this(v1, "v2", "v3"){ }
        public SomeClass() : this("var1"){
            var2 = "var2";
            var3 = "var3";
        }

        public override string ToString(){
            return $"{var1}, {var2}, {var3}";
        }
    }
    public class SomeParrentClass{
        protected SomeParrentClass(string test){
            Console.WriteLine("SomeParrentClass " + test);
        }
    }
}
