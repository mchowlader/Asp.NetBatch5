using System;

namespace _1035
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine();
            var inputSplit = input.Split(' ');

            var A = int.Parse(inputSplit[0]);
            var B = int.Parse(inputSplit[1]);
            var C = int.Parse(inputSplit[2]);
            var D = int.Parse(inputSplit[3]);


            if(B > C && D > A && (C+D) > (A+B) && C > 0 && D > 0 && A % 2 == 0)
            {
                Console.WriteLine("Valores aceitos");
                
            }
            else
            {
                Console.WriteLine("Valores nao aceitos");
            }
        }
    }
}
