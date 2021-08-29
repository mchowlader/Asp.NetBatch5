using AutoMapper;
using CRUD_One.Training.BusinessObjects;
using CRUD_One.Training.UnitOfWorks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUD_One.Training.Services
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

        public void CreateCourse(Course coure)
        {
            _trainingUnitOfWork.Courses.Add(
                _mapper.Map<Entities.Course>(coure));
            _trainingUnitOfWork.Save();
        }

        public void DeleteCourse(int id)
        {
            _trainingUnitOfWork.Courses.Remove(id);
            _trainingUnitOfWork.Save();
        }

        public (IList<Course> records, int total, int totalDisplay) GetCourseData(int pageIndex, 
            int pageSize, string searchText, string sortText)
        {
            var resultData = _trainingUnitOfWork.Courses.GetDynamic(
                string.IsNullOrWhiteSpace(searchText) ? null : x => x.Title.Contains(searchText), 
                sortText, string.Empty, pageIndex, pageSize);

            var resultCourse = (from data in resultData.data
                             select _mapper.Map<Course>(data)).ToList();

            return (resultCourse, resultData.total, resultData.totalDisplay);
        }

        public Course GetCourses(int id)
        {
            var course = _trainingUnitOfWork.Courses.GetById(id);
            return _mapper.Map<Course>(course);
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
