using System;

namespace Inheritance
{
    class Program
    {
        static void Main(string[] args)
        {
            var c = new Circle();
            c.LogType();
            Console.ReadKey();
        }
    }

    public class BaseShape{
        protected string type{get; set;}
        protected BaseShape(){ Console.WriteLine("BaseShape"); }

        protected void LogType(){
            Console.WriteLine("type = "+ type);
        }
    }
    public class Shape : BaseShape{
        protected Shape(){ Console.WriteLine("Shape"); }
    }

    public class Circle : Shape{
        public Circle(){
            base.type = "circle";
        }

        public new void LogType(){
            base.LogType();
        }
    }
}
