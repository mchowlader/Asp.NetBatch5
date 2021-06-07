using System;

namespace _1021
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine();

            var AD = Convert.ToInt32(input.Split('.')[1].Trim());
            var amount = Convert.ToInt32(input.Split('.')[0].Trim());

 
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
            var p1 = amount / 1;
            amount = amount % 1;


            var p_50 = AD / 50;
            AD = AD % 50;
            var p_25 = AD / 25;
            AD = AD % 25;
            var p_10 = AD / 10;
            AD = AD % 10;
            var p_05 = AD / 5;
            AD = AD % 5;
            var p_01 = AD / 1;
            AD = AD % 1;


            Console.WriteLine("NOTAS:");
            Console.WriteLine($"{x100} nota(s) de R$ 100.00");
            Console.WriteLine($"{x50} nota(s) de R$ 50.00");
            Console.WriteLine($"{x20} nota(s) de R$ 20.00");
            Console.WriteLine($"{x10} nota(s) de R$ 10.00");
            Console.WriteLine($"{x5} nota(s) de R$ 5.00");
            Console.WriteLine($"{x2} nota(s) de R$ 2.00");


            Console.WriteLine("MOEDAS:");
            Console.WriteLine($"{p1} moeda(s) de R$ 1.00");
            Console.WriteLine($"{p_50} moeda(s) de R$ 0.50");
            Console.WriteLine($"{p_25} moeda(s) de R$ 0.25");
            Console.WriteLine($"{p_10} moeda(s) de R$ 0.10");
            Console.WriteLine($"{p_05} moeda(s) de R$ 0.05");
            Console.WriteLine($"{p_01} moeda(s) de R$ 0.01");

        }
    }
}
