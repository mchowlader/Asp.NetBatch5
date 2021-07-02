using MVC.Training.BusinessObjects;
using MVC.Training.UnitOfWorks;
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
        public readonly ITrainingUnitOfWork _trainingUnitOfWork ;

        public CourseService(ITrainingUnitOfWork trainingUnitOfWork)
        {
            _trainingUnitOfWork = trainingUnitOfWork;
        }

        public IList<Course> GetAllCourses()
        {
            var courseentities = _trainingUnitOfWork.CourseRepository.GetAll();
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

        public void CreateCourse(Course course)
        {
            _trainingUnitOfWork.CourseRepository.Add(
                    new Traning.Entities.Course
                    { 
                        Id = course.Id,
                        Title = course.Title,
                        Fees = course.Fees,
                        StartDate = course.StartDate
                    }
                );

            _trainingUnitOfWork.Save();
        }
    }
}
