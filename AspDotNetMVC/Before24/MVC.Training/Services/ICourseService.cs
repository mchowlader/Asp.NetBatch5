using MVC.Training.BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC.Training.Services
{
    public interface ICourseService
    {
        IList<Course> GetAllCourses();
        void CreateCourse(Course course);
        (IList<Course>records, int total, int totalDisplay) GetCourses
            (int pageIndex, int pageSize, string searchText, string sortText);
    }
}
