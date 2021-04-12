using System;
using System.Collections.Generic;
using System.Linq;

namespace Linq
{
    class Program
    {
        static void Main(string[] args)
        {
            Student students = new Student();
            //StudentData studentsData = new StudentData();

            var find =
                from sD in studentData
                where sD.Name.StartsWith("A")
                select sD;

            foreach(var item in find)
            {
                Console.WriteLine($"SHOW: {item.Name}");
            }
        }

        static List<Student> studentData = new List<Student>
        {
            new Student{Name = "Joannes", Age = 25, Id = 1, Score = new List<int>{70,80,90,50,65}},
            new Student{Name = "Joseph", Age = 26, Id = 2, Score = new List<int>{80,50,85,70,60}},
            new Student{Name = "Anna", Age = 24, Id = 3, Score = new List<int>{60,80,90,56,88 }},
            new Student{Name = "Andreas", Age = 25,Id = 4, Score = new List<int>{77,89, 65,45,40}},
            new Student{Name = "Susanna", Age = 27, Id = 5, Score = new List<int>{90,40,67,88,77}}

        };
    }
}
