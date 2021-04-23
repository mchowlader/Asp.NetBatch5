using System;

namespace Task_3
{
    class Program
    {
        static void Main(string[] args)
        {
            SampleClass sampleClass = new SampleClass();
            var type = sampleClass.GetType().Assembly;
            var type1 = sampleClass.GetType().BaseType;
            Console.WriteLine(type1);
        }
    }
}
