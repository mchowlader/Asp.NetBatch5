using MVC.Data;
using MVC.Training.Entities;
using System;
using System.Collections.Generic;

namespace MVC.Traning.Entities
{
    public class Student : IEntity<int>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime DateOfBirth { get; set; }
        public List<CourseStudent> EnrolledCourses { get; set; }
    }
}
