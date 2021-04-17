using System;
using System.Linq;

namespace Linq_MSDN
{
    public class Program
    {
        static void Main(string[] args)
        {


            var info = new Student();


            var query =
                from st in info.studentsInfo
                where st.Id == 1
                select st;
            foreach (var item in query)
            {
                Console.WriteLine($"{item}");
            }


            //var Query1 =
            //      from st in students
            //      where st.Last == "Hupko"
            //      select st;
            //foreach(var item in Query1)
            //{
            //    Console.WriteLine($"Name: {item.First}");
            //}
        }

        //static List<Student> students = new List<Student>()
        //{
        //    new Student{First = "Andreas",Last = "Hupko", Dept = "EEE", Id = 1,Gender = G.M, Score = new List<int>{ 80,70,60,96,40} },
        //    new Student{First = "Anna",Last = "", Dept = "CSE", Id = 2,Gender = G.F ,Score = new List<int>{ 70,80,50,86,50} },
        //    new Student{First = "Victor",Last = "Andrea", Dept = "TEXT", Id = 3,Gender = G.B ,Score = new List<int>{ 90,80,60,26,40} },
        //    new Student{First = "Joseph",Last = "Hupko", Dept = "ENG", Id = 4,Gender = G.M,Score = new List<int>{ 10,60,90,46,49} },
        //    new Student{First = "Theresia",Last = "Vassik", Dept = "MATH", Id = 5,Gender = G.F ,Score = new List<int>{ 90,57,86,69,40}, },
        //    new Student{First = "Veronica",Last = "Andrea", Dept = "MATH", Id = 5,Gender = G.F,Score = new List<int>{ 90,57,86,69,40}, },

        //};


    }
}
