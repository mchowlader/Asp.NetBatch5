using AutoMapper;
using ExamTimeChallenge.Training.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Autofac;
using ExamTimeChallenge.Training.BusinessObjects;

namespace ExamTimeChallenge.Web.Areas.Admin.Models
{
    public class EditCourseModel
    {
        public int Id { get; set; }
        public int Fees { get; set; }
        public string Title { get; set; }
        public DateTime StartDate { get; set; }

        private readonly IMapper _mapper;
        private readonly ICourseService _courseService;

        public EditCourseModel()
        {
            _mapper = Startup.AutofacContainer.Resolve<IMapper>();
            _courseService = Startup.AutofacContainer.Resolve<ICourseService>();
        }
        public EditCourseModel(IMapper mapper, ICourseService courseService)
        {
            _mapper = mapper;
            _courseService = courseService;
        }

        internal void LoadModelData(int id)
        {
            var course = _courseService.GetCourseData(id);
            _mapper.Map(course, this);
        }

        internal void UpdateCourse()
        {
            var course = _mapper.Map<Course>(this);
            _courseService.UpdateCourse(course);
        }

    }
}
