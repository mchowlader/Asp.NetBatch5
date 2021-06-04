using System;

namespace _1014
{
    class Program
    {
        static void Main(string[] args)
        {
            var X = Convert.ToInt32(Console.ReadLine());
            var Y = Convert.ToDouble(Console.ReadLine());
           
            var XY = X / Y;

            Console.WriteLine($"{string.Format("{0:0.000}", XY)} km/l");
           
        }
    }
}
