using System;
using System.Collections.Generic;
using System.Linq;

namespace DictionaryEx1
{
    class Program
    {
        static void Main(string[] args)
        {
            IDictionary<int, string> info = new Dictionary<int, string>();

            info.Add(1, "Anna");
            info.Add(2, "Maria");
            info.Add(3, "Josef");

            //info[1] = "Susanna";  //update

            //info.Remove(1);       //Remove

            //var x = info.ContainsKey(1);
            //Console.WriteLine(x);

            //var x = info.Count;
            //Console.WriteLine(x);

            info.Clear();

            foreach (var item in info)
            {
                Console.WriteLine(item);
            }
        }
    }
}
