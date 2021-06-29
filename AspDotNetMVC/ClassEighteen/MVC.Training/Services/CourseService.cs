using MVC.Training.BusinessObjects;
using MVC.Training.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace MVC.Training.Services
{
    public class CourseService : ICoursesService
    {
        private readonly TrainingDbContext _trainingDbContext;

        public CourseService(TrainingDbContext trainingDbContext)
        {
            _trainingDbContext = trainingDbContext;
        }

        public IList<Course> GetAllCourses()
        {
            var courseEntities = _trainingDbContext.Course.ToList();
            var courses = new List<Course>();

            foreach(var entity in courseEntities)
            {
                var course = new Course()
                {
                    Id = entity.Id,
                    Titel = entity.Title,
                    Fees = entity.Fees,
                    StartDate = entity.StartDate
                    
                };

                courses.Add(course);
            }

            return courses;
        }
    }
}
