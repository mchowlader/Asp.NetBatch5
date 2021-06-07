using System;

namespace _1017
{
    class Program
    {
        static void Main(string[] args)
        {
            var hr = Convert.ToInt32(Console.ReadLine());
            var avSpeed = Convert.ToInt32(Console.ReadLine());

            double calculate = (hr * avSpeed) / 12.0;

            Console.WriteLine("{0:0.000}", calculate);
        }
    }
}
