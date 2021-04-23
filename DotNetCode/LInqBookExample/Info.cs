using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LInqBookExample
{
   public class Info
    {
        public string First { get; set; }

        public string Last { get; set; }

        public string Dept { get; set; }

        public int Id { get; set; }

        public G Gender { get; set; }

        public List<int> Score { get; set; }


        public static List<Info> studentsInfo = new List<Info>()
        {
            new Info{First = "Andreas",Last = "Hupko", Dept = "EEE", Id = 1,Gender = G.M, Score = new List<int>{ 80,70,60,96,40}},
            new Info{First = "Anna",Last = "Hupko", Dept = "CSE", Id = 2,Gender = G.F ,Score = new List<int>{ 70,80,50,86,50} },
            new Info{First = "Victor",Last = "Andrea", Dept = "TEXT", Id = 3,Gender = G.B ,Score = new List<int>{ 90,80,60,26,40}},
            new Info{First = "Joseph",Last = "Hupko", Dept = "ENG", Id = 4,Gender = G.M,Score = new List<int>{ 10,60,90,46,49}},
            new Info{First = "Theresia",Last = "Vassik", Dept = "MATH", Id = 5,Gender = G.F ,Score = new List<int>{ 90,57,86,69,40}}


        };

        public static List<Info> studentsInfo2 = new List<Info>()
        {
            new Info{First = "Andreas",Last = "Hupko", Dept = "EEE", Id = 6,Gender = G.M, Score = new List<int>{ 80,70,60,96,40} },
            new Info{First = "Josephi",Last = "Hupko", Dept = "CSE", Id = 7,Gender = G.F ,Score = new List<int>{ 70,80,50,86,50} },
            new Info{First = "Susanna",Last = "Andrea", Dept = "TEXT", Id = 8,Gender = G.B ,Score = new List<int>{ 90,80,60,26,40} },
            new Info{First = "Jacob",Last = "Hupko", Dept = "ENG", Id = 9,Gender = G.M,Score = new List<int>{ 10,60,90,46,49} },
            new Info{First = "Veronica",Last = "Andrea", Dept = "MATH", Id = 10,Gender = G.F,Score = new List<int>{ 90,57,86,69,40}, },

        };
    }
}
