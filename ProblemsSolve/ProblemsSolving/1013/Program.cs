using System;

namespace _1013
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine();
            var value = input.Split(' ');

            var A = Convert.ToInt32(value[0]);
            var B = Convert.ToInt32(value[1]);
            var C = Convert.ToInt32(value[2]);

            //var AB = (A + B + Math.Abs(A - B))/2;
            //Console.WriteLine(AB);

            var temp = A;

            if (A < B || A < C)
            {
                if (B < C)
                {
                    temp = C;
                }
                else
                {
                    temp = B;
                }
            }

            Console.WriteLine($"{temp} eh o maior");


        }
    }
}
