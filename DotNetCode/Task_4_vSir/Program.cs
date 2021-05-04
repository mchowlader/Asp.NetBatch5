using System;
using System.Linq;
using System.Collections.Generic;

namespace Task_4_vSir
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Student> List1 = new List<Student> { new Student { Name = "Josef", Age = 20}, new Student {Name = "Maria", Age = 25 } };
            List<Student> List2 = new List<Student> { new Student {Name = "Anna", Age = 23 }, new Student {Name = "Janos", Age = 24 } };
            
            //foreach(var item in List1)
            //{
            //    Console.WriteLine($"{item.Name} {item.Age}");
            //}

            List<string> result = (from st in List1.Union(List2)
                                   orderby st.Name, st.Age
                                   select st.Name).ToList();

            foreach(var item in result)
            {
                Console.WriteLine(item);
            }
        
        
        }
    }

    public class Student
    { 
    
        public string Name { get; set; }

        public int Age { get;set; }
    }


}
