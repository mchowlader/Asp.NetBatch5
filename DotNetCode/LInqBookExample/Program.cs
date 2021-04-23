using System;
using System.Collections.Generic;
using System.Linq;

namespace LInqBookExample
{
    class Program
    {
        static void Main(string[] args)
        {           
            List<string> result = null;

            var Query1 =
                from item in Info.studentsInfo.Concat(Info.studentsInfo2)
                orderby item.First, item.Id ascending
                select item.First;

            var QueryM1 =
                  Info.studentsInfo.Concat(Info.studentsInfo2).
                  OrderBy(ft => ft.First).
                  ThenByDescending(i => i.Id);

            //foreach(var item in QueryM1)
            //{
            //    Console.WriteLine($"Name : {item.First} Id : {item.Id} ");
            //}


            var Query2 =
                from item2 in Info.studentsInfo
                where item2.Score[4] > 40
                select item2.Id;

            var QueryM2 = Info.studentsInfo.Where(s => s.Score[2] > 50);
            foreach(var item in QueryM2)
            {
                Console.WriteLine(item.First);
            }
            
        }
    }
}
