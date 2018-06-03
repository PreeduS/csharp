using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Reflection2
{
    class Program
    {
        static void Main(string[] args)
        {

            Type vecType = typeof(Vector);
            var vecInstance = Activator.CreateInstance(vecType);// as Vector;
            PropertyInfo vecX = vecType.GetProperty("X");
            PropertyInfo vecY = vecType.GetProperty("Y");
            vecX.SetValue(vecInstance, 10);
            vecY.SetValue(vecInstance, 20);

            MethodInfo ToStringMethod = vecType.GetMethod("ToString");
            string result = ToStringMethod.Invoke(vecInstance, new object[]{} ) as string;

            MethodInfo WriteLinegMethod = typeof(Console).GetMethod(nameof(Console.WriteLine), new Type[]{typeof(string)} );
            WriteLinegMethod.Invoke(null, new String[]{result} );

            //access private
            Console.WriteLine("TestProp = " + 
            typeof(Vector).GetProperty("TestProp", BindingFlags.NonPublic | BindingFlags.Instance)?.GetValue(vecInstance) );
            /*
            Assembly assembly = Assembly.GetExecutingAssembly();
            assembly.GetTypes().FirstOrDefault().GetMembers()
            .ToList().ForEach(x => {
                Console.WriteLine(x.Name + ", " + x.MemberType); 
            });
            */

        }


    }

    public class Vector{

        public int X {get; set;}
        public int Y {get; set;}

        private string TestProp {get; set;} = "Test prop";

        public override string ToString(){
            return $"ToString: {X}, {Y}";
        }
        public static List<int> GetList(){
            return new List<int>();
        }

    }

}
