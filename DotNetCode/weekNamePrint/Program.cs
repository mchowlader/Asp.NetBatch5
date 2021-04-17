using System;
using System.Linq;

namespace weekNamePrint
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] weekName = new string[7];
            weekName[0] = "Saturday";
            weekName[1] = "Sunday";
            weekName[2] = "Monday";
            weekName[3] = "Tuesday";
            weekName[4] = "Wednesday";
            weekName[5] = "Thusday";
            weekName[6] = "Friday";

            var Query1 =
                from week in weekName
                where week.StartsWith("S")
                select week;

            //foreach(var item in Query1)
            //{
            //    Console.WriteLine($"Name: {item}");
            //}

            var Query2 =
                from week in weekName
                select week;
            foreach (var item in Query2)
            {
                Console.WriteLine(item);
            }

        }
    }
}
