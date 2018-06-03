using System;

namespace Enums
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine($"{MyEnum.Value}, {(int)MyEnum.Value}");      //Value, 0
            Move(Direction.Right);

            foreach(var e in Enum.GetValues(typeof (MyEnum))){
                Console.WriteLine($"{e} - {(int)e}");
            }
        }

        public enum Direction : short{
            Left = 0,
            Right = 1,
            Top = 2,
            Bottom = 3,
        }
        public static void Move(Direction direction){
            switch(direction){
                case Direction.Left:
                    Console.WriteLine("Moving left"); 
                    break;
                case Direction.Right:
                    Console.WriteLine("Moving right"); 
                    break;
            }
        }
        
        enum MyEnum{
            Value,      //0
            Value2,     //1
            Value3,     //2
            Value4 = 14, //14
            Value5,     //15
            Value6,     //15
        }
    }
}
