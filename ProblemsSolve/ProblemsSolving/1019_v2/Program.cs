using System;

namespace _1019_v2
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Convert.ToInt32(Console.ReadLine());

            var H = 60 * 60;
            var M = 60;
            var S = 1;

            var Hour = input / H;
            input = input % H;

            var Minutes = input / M;
            input = input % M;

            var Second = input / S;
            input = input % S;

            Console.WriteLine($"{Hour}:{Minutes}:{Second}");
        }
    }
}
