using System;
using System.Collections.Generic;

namespace Builder
{
    class Program
    {
        static void Main(string[] args)
        {
            //CvBuilder cvBuilder = new CvBuilder();
            //cvBuilder.AddName("Mithun Chandra Howlader");
            //cvBuilder.AddImage("MCH.jpg");
            //cvBuilder.AddProjects("DevSkill", new DateTime(2021, 04, 09), new DateTime(2021, 10, 09), 
            //    new List<string> {"C#","Asp.Net"});

            //CV cV = cvBuilder.GetCV();


            //method chaining

            CV cV = new CvBuilder()
            .AddName("Mithun Chandra Howlader")
            .AddImage("MCH.jpg")
            .AddProjects("DevSkill", new DateTime(2021, 04, 09), new DateTime(2021, 10, 09),
                new List<string> { "C#", "Asp.Net" })
            .GetCV();

        }
    }
}
