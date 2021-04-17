using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Linq_MSDN
{
    public class Student
    {
        public string First { get; set; }

        public string Last { get; set; }

        public string Dept { get; set; }

        public int Id { get; set; }

        public G Gender { get; set; }

        public List<int> Score { get; set; }


        public List<Student> studentsInfo = new List<Student>()
        {
            new Student{First = "Andreas",Last = "Hupko", Dept = "EEE", Id = 1,Gender = G.M, Score = new List<int>{ 80,70,60,96,40} },
            new Student{First = "Anna",Last = "", Dept = "CSE", Id = 2,Gender = G.F ,Score = new List<int>{ 70,80,50,86,50} },
            new Student{First = "Victor",Last = "Andrea", Dept = "TEXT", Id = 3,Gender = G.B ,Score = new List<int>{ 90,80,60,26,40} },
            new Student{First = "Joseph",Last = "Hupko", Dept = "ENG", Id = 4,Gender = G.M,Score = new List<int>{ 10,60,90,46,49} },
            new Student{First = "Theresia",Last = "Vassik", Dept = "MATH", Id = 5,Gender = G.F ,Score = new List<int>{ 90,57,86,69,40}, },
            new Student{First = "Veronica",Last = "Andrea", Dept = "MATH", Id = 5,Gender = G.F,Score = new List<int>{ 90,57,86,69,40}, },

        };

    }
}
