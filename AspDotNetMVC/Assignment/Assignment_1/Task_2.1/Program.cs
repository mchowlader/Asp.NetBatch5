using System;

namespace Task_2._1
{
    class Program
    {
        static void Main(string[] args)
        {
            ReflectionUtility reflectionUtility = new ReflectionUtility();
            ClassWithPrivateMethod classWithPrivateMethod = new ClassWithPrivateMethod();

            reflectionUtility.CallPrivate(classWithPrivateMethod, "Print", new object[] { "hi" });

        }
    }

    public class ReflectionUtility
    {
        ClassWithPrivateMethod classWithPrivateMethod = new ClassWithPrivateMethod();

        public void CallPrivate(object targetObject, string methodName, object[] args)
        {
            var item = classWithPrivateMethod.GetType()
                .GetMethod("Print", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance)
                .Invoke(classWithPrivateMethod, args);
            
        }
    }

    public class ClassWithPrivateMethod
    {
        private void Print(string name)
        {
            Console.WriteLine(name);
        }
    }

}
