using MVC.Common.Utilities;
using MVC.Exceptions;
using MVC.Training.BusinessObjects;
using MVC.Training.Contexts;
using MVC.Training.UnitOfWorks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC.Training.Services
{
    public class CourseService : ICourseService
    {
        private readonly ITrainingUnitOfWork _trainingUnitOfWork;
        private readonly IDateTimeUnity _dateTimeUnity;
        public CourseService(ITrainingUnitOfWork trainingUnitOfWork, IDateTimeUnity dateTimeUnity)
        {
            _trainingUnitOfWork = trainingUnitOfWork;
            _dateTimeUnity = dateTimeUnity;
        }

        public void CreateCourse(Course course)
        {
            if (course == null)
                throw new InvalidParameterException("Invalid Course");
            if (IsTitleAlreadyUsed(course.Title))
                throw new DuplicateTitleException("Title already exits");
            if (!IsValidstartDate(course.StartDate))
                throw new InvalidDateException("Invalid Date");

            _trainingUnitOfWork.Courses.Add
                (
                    new Entities.Course 
                    {
                        Title = course.Title,
                        Fees = course.Fees,
                        StartDate = course.StartDate
                    }
                );

            _trainingUnitOfWork.save();
        }

        public IList<Course> GetAllCourses()
        {
            var courseEntities = _trainingUnitOfWork.Courses.GetAll();
            var courseList = new List<Course>();
            foreach(var entity in courseEntities)
            {
                var course = new Course()
                {
                    Title = entity.Title,
                    Fees = entity.Fees,
                    StartDate = entity.StartDate
                };
                courseList.Add(course);
            }
            return courseList;
        }

        public (IList<Course> records, int total, int totalDisplay) GetCourses(int pageIndex, int pageSize, 
            string searchText, string sortText)
        {
            var courseData = _trainingUnitOfWork.Courses.GetDynamic(x => x.Title == searchText, sortText, 
                string.Empty, pageIndex, pageSize);
            var resultData = (from course in courseData.data
                              select new Course
                              {
                                  Id = course.Id,
                                  Title = course.Title,
                                  Fees = course.Fees,
                                  StartDate = course.StartDate
                              }).ToList();
            return (resultData, courseData.total, courseData.totalDisplay);
        }

        private bool IsTitleAlreadyUsed(string title) => 
            _trainingUnitOfWork.Courses.GetCount(x => x.Title == title) > 0;
        private bool IsValidstartDate(DateTime dateTime) => 
            dateTime.Subtract(_dateTimeUnity.NowTime).TotalDays > 30;

    }
}
