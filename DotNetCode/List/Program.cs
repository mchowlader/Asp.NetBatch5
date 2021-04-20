using System;
using System.Collections.Generic;
using System.Linq;

namespace List
{
    class Program
    {
        static void Main(string[] args)
        {

            Part part = new Part();

            var query =
                from p in part.parts
                where p.PartName = "A"
                select p;










            //foreach (Part aPart in parts)
            //{
            //    Console.WriteLine(aPart);
            //}

        }
    }
}
