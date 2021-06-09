using System;

namespace _1000
{
    class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine("Hello World!");


            var input = Convert.ToInt32(Console.ReadLine());

            var second = 0;
            var hour = 0;
            var minutes = 0;

            minutes = input / 60;
            input = input % 60;

            hour = input / 60;
            input = input % 60;

           

            second = input % 60;
            input = input % 60;

            Console.WriteLine($"{hour}:{minutes}:{second}");



        }
    }
}
