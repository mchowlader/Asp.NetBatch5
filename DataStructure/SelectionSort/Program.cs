using System;
using System.Collections;

namespace SelectionSort
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter your Array Size: ");
            var arrayLength = int.Parse(Console.ReadLine());

            int[] arrays = new int[arrayLength];
            Console.WriteLine("Enter your Array value: ");
            for (var i = 0; i < arrayLength; i++)
            {
                Console.Write("Element[{0}]:", i);
                arrays[i] = int.Parse(Console.ReadLine());
            }

            int temp = 0;
            for(var i = 0; i <= arrays.Length-1; i++)
            {
                var min = i;

                for (var k = i+1; k <= arrays.Length-1; k++)
                {
                    if (arrays[k] < arrays[min])
                    {
                        min = k;
                    }
                }

                temp = arrays[min];
                arrays[min] = arrays[i];
                arrays[i] = temp;
            }

            Console.WriteLine("Selection Sort Output: ");
            foreach (var item in arrays)
            {
                Console.WriteLine($"{item}");
            }
        }
    }
}
