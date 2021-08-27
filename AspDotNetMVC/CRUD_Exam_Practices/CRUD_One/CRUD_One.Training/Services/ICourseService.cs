using CRUD_One.Training.BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUD_One.Training.Services
{
    public interface ICourseService
    {
        void CreateCourse(Course coure);
        (IList<Course> records, int total, int totalDisplay) GetCourseData(int pageIndex, 
            int pageSize, string searchText, string sortText);
        Course GetCourses(int id);
        void UpdateCourse(Course course);
        void DeleteCourse(int id);
    }
}
