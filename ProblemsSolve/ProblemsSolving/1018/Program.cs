using System;

namespace _1018
{
    class Program
    {
        static void Main(string[] args)
        {
            var amount = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine(amount);

            var x100 = amount / 100;
            amount = amount % 100;
            var x50 = amount / 50;
            amount = amount % 50;
            var x20 = amount / 20;
            amount = amount % 20;
            var x10 = amount / 10;
            amount = amount % 10;
            var x5 = amount / 5;
            amount = amount % 5;
            var x2 = amount / 2;
            amount = amount % 2;
            var x1 = amount / 1;
            amount = amount % 1;

            
            Console.WriteLine($"{x100} nota(s) de R$ 100,00");
            Console.WriteLine($"{x50} nota(s) de R$ 50,00");
            Console.WriteLine($"{x20} nota(s) de R$ 20,00");
            Console.WriteLine($"{x10} nota(s) de R$ 10,00");
            Console.WriteLine($"{x5} nota(s) de R$ 5,00");
            Console.WriteLine($"{x2} nota(s) de R$ 2,00");
            Console.WriteLine($"{x1} nota(s) de R$ 1,00");

        }
    }
}
