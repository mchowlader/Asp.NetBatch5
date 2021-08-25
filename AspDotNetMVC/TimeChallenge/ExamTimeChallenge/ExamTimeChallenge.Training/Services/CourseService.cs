using AutoMapper;
using ExamTimeChallenge.Training.BusinessObjects;
using ExamTimeChallenge.Training.UnitOfWorks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamTimeChallenge.Training.Services
{
    public class CourseService : ICourseService
    {
        private readonly ITrainingUnitOfWork _trainingUnitOfWork;
        private readonly IMapper _mapper;

        public CourseService(IMapper mapper, ITrainingUnitOfWork trainingUnitOfWork)
        {
            _mapper = mapper;
            _trainingUnitOfWork = trainingUnitOfWork;
        }

        public void CreateCourse(Course course)
        {
            _trainingUnitOfWork.Courses.Add(
                _mapper.Map<Entities.Course>(course));
            _trainingUnitOfWork.Save();
        }

        public void DeleteCourse(int id)
        {
            _trainingUnitOfWork.Courses.Remove(id);
            _trainingUnitOfWork.Save();
        }

        public (IList<Course> records, int total, int totalDisplay) GetCourseData(int pageIndex, int pageSize, 
            string searchText, string sorting)
        {
            var courseResult = _trainingUnitOfWork.Courses.GetDynamic(
                string.IsNullOrWhiteSpace(searchText)? null:x => x.Title.Contains(searchText), 
                sorting, string.Empty, pageIndex, pageSize);

            var courseData = (from course in courseResult.data
                        select _mapper.Map<Course>(course)).ToList();

            return (courseData, courseResult.total, courseResult.totalDisplay);
        }

        public Course GetCourseData(int id)
        {
            var courseentity = _trainingUnitOfWork.Courses.GetById(id);
            return _mapper.Map<Course>(courseentity);
        }

        public void UpdateCourse(Course course)
        {
            if (course == null)
                throw new InvalidOperationException();
            var courseEntity = _trainingUnitOfWork.Courses.GetById(course.Id);

            if(courseEntity != null)
            {
                _mapper.Map(course, courseEntity);
                _trainingUnitOfWork.Save();
            }
        }
    }
}
