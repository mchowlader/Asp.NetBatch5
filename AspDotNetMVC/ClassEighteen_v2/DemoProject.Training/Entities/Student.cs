using DemoProject.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoProject.Training.Entities
{
    public class Student : IEntity<int>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<CourseStudent> EnrolledCourses { get; set; }
        public DateTime DateOfBirth { get; set; }
    }
}
