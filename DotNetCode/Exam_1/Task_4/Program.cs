using System;
using System.Collections.Generic;
using System.Linq;

namespace Task_4
{
   public class Program
    {
        static void Main(string[] args)
        {
         
            Student student = new Student();

            List<Student> list1 = new List<Student>()
            {  
                new Student{Name = "Anna", Age = 25},
                new Student{Name = "Joseph", Age = 20},
                new Student{Name = "Maria", Age = 30},
                new Student{Name = "Susanna", Age = 20},
                new Student{Name = "Andreas", Age = 49}
            };
            List<Student> list2 = new List<Student>()
            { 
                new Student{Name = "Josephi", Age = 50},
                new Student{Name = "Sophia", Age = 40},
                new Student{Name = "Joannes", Age = 55},
                new Student{Name = "Jacob", Age = 30},
                new Student{Name = "Martinus", Age = 20},

            };

            List<string> result = null;

            var listMerge = 
                from st in list1.Concat(list2)
                orderby st.Name , st.Age ascending
                select st.Name;

            foreach(var item in listMerge)
            {
                Console.WriteLine(item);
            }

                
            
        }
    }
}
