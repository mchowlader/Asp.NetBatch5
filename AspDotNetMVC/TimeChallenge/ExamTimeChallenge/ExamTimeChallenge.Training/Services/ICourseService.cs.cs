using ExamTimeChallenge.Training.BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamTimeChallenge.Training.Services
{
    public interface ICourseService
    {
        void CreateCourse(Course course);
        (IList<Course> records, int total, int totalDisplay) GetCourseData(int pageIndex, int pageSize, string searchText, string sorting);
        Course GetCourseData(int id);
        void UpdateCourse(Course course);
        void DeleteCourse(int id);
    }
}
