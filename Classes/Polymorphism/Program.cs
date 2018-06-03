using System;

namespace Polymorphism
{
    class Program
    {
        static void Main(string[] args)
        {
            Base bc = new Base();
            Derived dc = new Derived();
            Base bcdc = new Derived();

            bc.Method1();           //Base - Method1
            bc.Method2();           //Base - Method2
            Console.WriteLine();

            dc.Method1();           //Derived - Method1 - override
            dc.Method2();           //Derived - Method2 - new
            Console.WriteLine();

            bcdc.Method1();         //Derived - Method1 - override
            bcdc.Method2();         //Base - Method2                    //<--
            Console.WriteLine();
        }
    }

    public class Base{
        public virtual void Method1(){
            Console.WriteLine("Base - Method1");
        }
        public virtual void Method2(){
            Console.WriteLine("Base - Method2");
        }
    }
    public class Derived : Base{
        public override void Method1(){
            Console.WriteLine("Derived - Method1 - override");
        }
        public new void Method2(){
            Console.WriteLine("Derived - Method2 - new");
        }

    }



}
