using System;

namespace _1015
{
    class Program
    {
        static void Main(string[] args)
        {
            var P1 = Console.ReadLine();
            var P2 = Console.ReadLine();

            var XY1 = P1.Split(' ');
            var XY2 = P2.Split(' ');

            var x1 = Convert.ToDouble(XY1[0]);
            var y1 = Convert.ToDouble(XY1[1]);
            var x2 = Convert.ToDouble(XY2[0]);
            var y2 = Convert.ToDouble(XY2[1]);

            var distance = Math.Sqrt(Math.Pow((x2 - x1), 2) + Math.Pow((y2 - y1), 2));
            
            Console.WriteLine(string.Format("{0:0.0000}", distance));



        }
    }
}
