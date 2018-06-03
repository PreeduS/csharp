using System;
using System.Reflection;


namespace Reflection
{
    class Program
    {
        static void Main(string[] args){

            foreach(Type t in Assembly.GetExecutingAssembly().GetTypes()){
                
                foreach(Attribute a in t.GetCustomAttributes(false)){
                    if(a is TestClassAttribute){
                        Console.WriteLine(t.Name + " is " + a.GetType().Name);
                    }
                }
                Console.WriteLine();
                object instance = Activator.CreateInstance(t);

                foreach(MethodInfo m in t.GetMethods()){
                    foreach(Attribute a2 in m.GetCustomAttributes(false)){
                        if(a2 is TestMethodAttribute){
                            Console.WriteLine(m.Name + " is " + a2.GetType().Name);
                            m.Invoke(instance, new object[0]);
                        }
                    }
                                        
                }

            }//end foreach

            Console.WriteLine("IsDefined = " + (typeof (ClassA)).IsDefined(typeof(TestClassAttribute)) );
            Console.WriteLine("IsDefined = " + (typeof (ClassA)).IsDefined(typeof(TestMethodAttribute)) );


        
        }


    }

    public class TestClassAttribute : Attribute{ }
    [AttributeUsage(AttributeTargets.Method | AttributeTargets.Constructor, AllowMultiple = false)]
    public class TestMethodAttribute : Attribute{
        public TestMethodAttribute(){
            Console.WriteLine("ctor TestMethodAttribute empty");
        }
        public TestMethodAttribute(string p1){
            Console.WriteLine("ctor TestMethodAttribute " + p1);
        }
        public int MaxLength{ get; set; }
    }

    [TestClass]
    public class ClassA{

        [TestMethod]
        public void Method1(){}
        
        [TestMethod("param 1",MaxLength = 10)]
        public void Method2(){
            Console.WriteLine("Method 2 call");
        }
    }
    public class ClassB{}
}
