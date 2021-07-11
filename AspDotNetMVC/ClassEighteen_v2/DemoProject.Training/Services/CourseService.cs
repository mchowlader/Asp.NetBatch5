using DemoProject.Training.BusinessObjects;
using DemoProject.Training.Contexts;
using DemoProject.Training.Exceptions;
using DemoProject.Training.UnitOfWorks;
using System;
using System.Collections.Generic;

namespace DemoProject.Training.Services
{
    public class CourseService : ICourseService
    {
        private readonly ITrainingUnitOfWork _trainingUnitOfWork;
        public CourseService(ITrainingUnitOfWork trainingUnitOfWork)
        {
            _trainingUnitOfWork = trainingUnitOfWork;
          
        }
        public IList<Course> GetAllCourse()
        {
            var courseEntities = _trainingUnitOfWork.Courses.GetAll();
            var courses = new List<Course>();
            foreach(var entity in courseEntities)
            {
                var course = new Course()
                {
                    Titel = entity.Titel,
                    Fees = entity.Fees
                };
                courses.Add(course);
            }
            return courses;
        }
        public void CreateCourse(Course course)
        {
            if (course == null)
                throw new InvalidParameterException("Course was not provided");
            if (IsTitleAlreadyUsed(course.Titel))
                throw new InvalidOperationException("Title already Exits");

            {
                _trainingUnitOfWork.Courses.Add
                (
                    new Entities.Course
                    {
                        Titel = course.Titel,
                        Fees = course.Fees,
                        StartDate = course.StartDate
                    }
                );

                _trainingUnitOfWork.Save();
            }

        }
        public void EnrollStudent(Course course, Student student)
        {
            var courseEntity = _trainingUnitOfWork.Courses.GetById(course.Id);

            if (courseEntity == null)
                throw new InvalidOperationException("Course not found");

            if (courseEntity.EnrolledStudents == null)
                courseEntity.EnrolledStudents = new List<Entities.CourseStudent>();

            courseEntity.EnrolledStudents.Add(new Entities.CourseStudent 
            {
                Student = new Entities.Student
                {
                    Name = student.Name,
                    DateOfBirth = student.DateOfBirth
                }
            });

            _trainingUnitOfWork.Save();
        }

        private bool IsTitleAlreadyUsed(string title) =>
            _trainingUnitOfWork.Courses.GetCount(x => x.Titel == title) > 0;

    }
}
