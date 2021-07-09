using DemoProject.Training.BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoProject.Training.Services
{
    public interface ICourseService
    {
        IList<Course> GetAllCourse();
        void EnrollStudent(Course course, Student student);

    }
}
