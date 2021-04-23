using System;
using System.Linq;
using System.Collections.Generic;

namespace Task_4
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> result = null;

            var Query1 =
                from item in Student.studentsInfo.Concat(Student.studentsInfo2)
                orderby item.First, item.Id ascending
                select item.First;

            result = new List<string>();
            foreach (var item in Query1)
            {
                result.Add(item);
            }

            foreach (var item2 in result)
            {
                if (String.IsNullOrWhiteSpace(item2))
                {
                    break;
                }
                Console.WriteLine($"Name :{item2}");
            }
    }   }   
}
