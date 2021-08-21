using AutoMapper;
using MVC.Common.Utilities;
using MVC.Training.BusinessObjects;
using MVC.Training.Exceptions;
using MVC.Training.UnitOfWorks;
using MVC.Traning.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EO = MVC.Traning.Entities;

namespace MVC.Training.Services
{
    public class CourseService : ICourseService
    {
        private readonly ITrainingUnitOfWork _trainingUnitOfWork ;
        private readonly IDateTimeUtility _dateTimeUtility;
        private readonly IMapper _mapper;

        public CourseService(IMapper mapper, ITrainingUnitOfWork trainingUnitOfWork, IDateTimeUtility dateTimeUtility)
        {
            _mapper = mapper;
            _trainingUnitOfWork = trainingUnitOfWork;
            _dateTimeUtility = dateTimeUtility;
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
            if (course.Title == null)
                throw new InvalidParameterException("Course was not provided"); 
          
            if (IsTitelAlreadyUsed(course.Title))
                throw new DuplicateTitelException("Course titel already exits");

            if (!IsValidStartDate(course.StartDate))
                throw new InvalidParameterException("Start date should be atleast ahead 30 days");

            {
                _trainingUnitOfWork.CourseRepository.Add(
                    _mapper.Map<EO.Course>(course));

                        //new Traning.Entities.Course
                        //{
                        //    Title = course.Title,
                        //    Fees = course.Fees,
                        //    StartDate = course.StartDate
                        //}
                   
                _trainingUnitOfWork.Save();
            }

        }

        public void EnrollStudent(Course course, Student student)
        {
            var courseEntity = _trainingUnitOfWork.CourseRepository.GetById(course.Id);

            if (courseEntity == null)
                throw new InvalidOperationException("Course not found");

            if (courseEntity.EnrolledStudents == null)
                courseEntity.EnrolledStudents = new List<Entities.CourseStudent>();

            courseEntity.EnrolledStudents.Add(new Entities.CourseStudent 
            
            {
                Student =new Traning.Entities.Student
                {
                    Name = student.Name,
                    DateOfBirth = DateTime.Now
                }
            });

            _trainingUnitOfWork.Save();
        }

        private bool IsTitelAlreadyUsed(string titel) =>
            _trainingUnitOfWork.CourseRepository.GetCount(x => x.Title == titel) > 0;

        private bool IsValidStartDate(DateTime startdate) 
            => startdate.Subtract(_dateTimeUtility.Now).TotalDays > 30;
    }
}
