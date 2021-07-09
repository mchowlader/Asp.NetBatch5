using DemoProject.Data;
using System;
using System.Collections.Generic;

namespace DemoProject.Training.Entities
{
    public class Course : IEntity<int>
    {
        public int Id { get; set; }
        public string Titel { get; set; }
        public int Fees { get; set; }
        public List<CourseStudent> EnrolledStudents { get; set; }
        public DateTime StartDate { get; set; }
        public List<Topic> Topic { get; set; }
        
    }
}
