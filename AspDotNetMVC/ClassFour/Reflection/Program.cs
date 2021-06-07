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
                    var constroctor = type.GetConstructor(new Type[0]);
                }
            }



            Console.WriteLine(initClassName);
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
             /*
            Type type = typeof(Product);

            Product product = new Product();
            Type productType = product.GetType();
            */
        }
    }
}
