using System;
using System.IO;
using System.Reflection;

namespace Reflection
{
    class Program
    {
        static void Main(string[] args)
        {

            var path = @"D:\DevSkill\dotNet\Code\Asp.NetBatch5\AspDotNetMVC\ClassFour\Reflection\Config.txt";
            var confiText = File.ReadAllText(path);

            var initClassName = confiText.Split('=')[1].Trim();

            Type[] types = Assembly.GetExecutingAssembly().GetTypes();

            foreach(var type in types)
            {
               if (type.Name == initClassName)
                {
                    var constroctor = type.GetConstructor(new Type[] { typeof(int)});
                    var InitializerInstance = constroctor.Invoke(new object[] { 5 });       

                    MethodInfo[] M = type.GetMethods();
                    foreach(var me in M)
                    {
                        if(me.Name == "InitStartup")
                        {
                            me.Invoke(InitializerInstance, new object[0]);                                                       
                        }
                    }
                }
            }

            
           
            
         
            Type type2 = typeof(Product);

            //foreach (var properti in type2.GetProperties())
            //{
            //    Console.WriteLine(properti.Name);
            //}

            foreach (var method in type2.GetMethods())
            {
                Console.WriteLine(method.Name);
            }



            /*
            Product product = new Product();
            Type productType = product.GetType();
            */
        }
    }
}
