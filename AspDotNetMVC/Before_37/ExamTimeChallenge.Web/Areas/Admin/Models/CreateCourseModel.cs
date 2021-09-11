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
    public class CreateCourseModel
    {
        public int Id { get; set; }
        public int Fees { get; set; }
        public string Title { get; set; }
        public DateTime StartDate { get; set; }

        private readonly IMapper _mapper;
        private readonly ICourseService _courseService;

        public CreateCourseModel()
        {
            _mapper = Startup.AutofacContainer.Resolve<IMapper>();
            _courseService = Startup.AutofacContainer.Resolve<ICourseService>();
        }
        public CreateCourseModel(IMapper mapper, ICourseService courseService)
        {
            _mapper = mapper;
            _courseService = courseService;
        }

        internal void CreateCourse()
        {
            var course = _mapper.Map<Course>(this);
            _courseService.CreateCourse(course);
        }
    }
}
