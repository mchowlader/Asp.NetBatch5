using System;
using System.Linq;

namespace stringCount
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter a string: ");
            var input = Console.ReadLine();

            var Query1 =
                from inp in input
                orderby inp
                group inp by inp.ToString();
                               
            foreach(var item in Query1)
            {
                Console.WriteLine($"{item.Key}, {item.Count()}");
            }



            //Console.WriteLine(input);
        }
    }
}
