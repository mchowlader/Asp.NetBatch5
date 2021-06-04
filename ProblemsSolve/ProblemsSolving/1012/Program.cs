using System;

namespace _1012
{
    class Program
    {
        static void Main(string[] args)
        {
            var pi = 3.14159;
            var input = Console.ReadLine();
            var value = input.Split(' ');

            var A = Convert.ToDouble(value[0]);
            var B = Convert.ToDouble(value[1]);
            var C = Convert.ToDouble(value[2]);

            var TRIANGULO = (A * C) / 2;
            var CIRCULO = Math.Pow(C,2) * pi;
            var TRAPEZIO = ((A + B) / 2) * C;
            var QUADRADO = Math.Pow(B,2);
            var RETANGULO = A * B;

            Console.WriteLine($"TRIANGULO: {String.Format("{0:0.000}", TRIANGULO)}");
            Console.WriteLine($"CIRCULO: {String.Format("{0:0.000}", CIRCULO)}");
            Console.WriteLine($"TRAPEZIO: {String.Format("{0:0.000}", TRAPEZIO)}");
            Console.WriteLine($"QUADRADO: {String.Format("{0:0.000}", QUADRADO)}");
            Console.WriteLine($"RETANGULO: {String.Format("{0:0.000}", RETANGULO)}");

        }
    }
}
