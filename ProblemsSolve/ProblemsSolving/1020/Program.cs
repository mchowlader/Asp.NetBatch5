using System;

namespace _1020
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = int.Parse(Console.ReadLine());

            var year = input / 365;
            input = input % 365;

            var month = input / 30;
            input = input % 30;

            var day = input;

            Console.WriteLine($"{year} ano(s)\n{month} mes(es)\n{day} dia(s)");
        }
    }
}
