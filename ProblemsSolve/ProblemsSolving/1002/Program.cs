using System;

namespace _1002
{
    class Program
    {
        static void Main(string[] args)
        {
            var n = 3.14159;
            var r = Convert.ToDouble(Console.ReadLine());
            var A = n * r * r;
            Console.WriteLine($"A={string.Format("{0:0.0000}",A)}");
        }
    }
}
