using System;

namespace _1036
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine();

            var inputSplit = input.Split(' ');

            var A = double.Parse(inputSplit[0]);
            var B = double.Parse(inputSplit[1]);
            var C = double.Parse(inputSplit[2]);

            var root = Math.Pow(B, 2) - 4 * A * C;

            if (root < 0 || A == 0)
            {
                Console.WriteLine("Impossivel calcular");
            }
            else
            {
                var R1 = ((-B + Math.Sqrt(root)) / (2 * A));
                var R2 = ((-B - Math.Sqrt(root)) / (2 * A));

                Console.WriteLine("R1 = {0:0.00000}", R1);
                Console.WriteLine("R2 = {0:0.00000}", R2);
            }
            
        }
    }
}


//Console.WriteLine($"R1 = {string.Format("{0:0.00000}",R1)}");
//Console.WriteLine($"R2 = {string.Format("{0:0.00000}",R2)}");