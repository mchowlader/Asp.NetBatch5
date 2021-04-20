using System;

using System.Collections.Generic;

namespace GenericListEx
{
    public class Program
    {
        static void Main(string[] args)
        {
            Data data = new Data();

            var yy = data.studentInfo;

            foreach(var item in yy)
            {
                Console.WriteLine(item.Id);
            }

            //List<Data> info3 = new List<Data>();

            //info3.Add(new Data() { Name = "cse", Id = 1, Gender = G.Male });

            //Console.WriteLine(info3.Count);
            //foreach (var item in info3)
            //{
            //    Console.WriteLine(item.Name);
            //}


            //List<string> info2 = new List<string>();
            //info2.Add("abid");
            //info2.Add("abid");
            //info2.Add("abid");

            //Console.WriteLine(info2.Count);         

            //foreach(var item in info2)
            //{
            //    Console.WriteLine(item);
            //}
            
            
        }

        
       
    }

}
