using System;
using System.IO;
using System.Reflection;

namespace ReflectionEx2
{
    class Program
    {
        static void Main(string[] args)
        {
            var path = @"D:\DevSkill\dotNet\Code\Asp.NetBatch5\DotNetCode\ReflectionEx2\Conflg.txt";

            var configText = File.ReadAllText(path);
            var initClassName = configText.Split("=")[1].Trim();

            Type[] types = Assembly.GetExecutingAssembly().GetTypes();  //GetExecutingAssembly bolte kon nam k bujhiyeche?

            foreach (var type in types)
            {
                if(type.Name == initClassName)
                {
                    var constroctor = type.GetConstructor(new Type[0]); //jethetu class a constroctor nei
                                                                        //tahole ki empty constroctor k bujhiyeche?
                                                                        //amra jehetu empty constructor deyarkotha vabchi kintu poreo deya hoy nai.
                                                                        //tar agei ki paramete bole deya jabe 

                    var initializerConstructor = constroctor.Invoke(new object[0]);
                    MethodInfo method = type.GetMethod("InitStartup");
                    method.Invoke(initializerConstructor, new object[0]);
                }
            }
        }
    }
}
