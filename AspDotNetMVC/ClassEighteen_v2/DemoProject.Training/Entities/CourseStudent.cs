using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoProject.Training.Entities
{
    public class CourseStudent
    {
        public int StudentId { get; set; }
        public Student Student { get;set; }
        public int CoursetId { get; set; }
        public Course Course { get; set; }
    }
}
