using System;

namespace _1011
{
    class Program
    {
        static void Main(string[] args)
        {
            var pi = 3.14159;
            var R = Convert.ToDouble(Console.ReadLine());
       
            var result = (4.0 / 3.0) * pi * Math.Pow(R, 3);
            Console.WriteLine($"VOLUME = {string.Format("{0:0.000}",result)}");
        }
    }
}
