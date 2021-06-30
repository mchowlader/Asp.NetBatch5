using MVC.Training.BusinessObjects;
using MVC.Traning.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC.Training.Services
{
    public class CourseService : ICourseService
    {
        public readonly TrainingDbContext _trainingDbContext;

        public CourseService(TrainingDbContext trainingDbContext)
        {
            _trainingDbContext = trainingDbContext;
        }

        public IList<Course> GetAllCourses()
        {
            var courseentities = _trainingDbContext.Courses.ToList();
            var courses = new List<Course>();

            foreach(var entity in courseentities)
            {
                var course = new Course() 
                {
                    Id = entity.Id,
                    Title = entity.Title,
                    Fees = entity.Fees,
                    StartDate = entity.StartDate
                };

                courses.Add(course);
            }

            return courses;
        }
    }
}
