using System;
using System.Collections;

namespace _1010
{
    class Program
    {
        static void Main(string[] args)
        {
            var p1 = Console.ReadLine();
            var psOne = p1.Split(' ');
            var product1Code = Convert.ToInt32(psOne[0]);
            var product1Unit =Convert.ToInt32(psOne[1]);
            var product1Price = Convert.ToDouble(psOne[2]);


            var p2 = Console.ReadLine();
            var psTwo = p2.Split(' ');
            var product2Code = Convert.ToInt32(psTwo[0]);
            var product2Unit = Convert.ToInt32(psTwo[1]);
            var product2Price = Convert.ToDouble(psTwo[2]);


            var result = (product1Unit*product1Price) + (product2Unit*product2Price);
            Console.WriteLine($"VALOR A PAGAR: R$ {string.Format("{0:0.00}" ,result)}");
            


        }
    }
}
