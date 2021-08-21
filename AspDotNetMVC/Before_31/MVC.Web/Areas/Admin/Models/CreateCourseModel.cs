using MVC.Training.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Autofac;
using MVC.Training.BusinessObjects;
using AutoMapper;

namespace MVC.Web.Areas.Admin.Models
{
    public class CreateCourseModel
    {
        public string Title { get; set; }
        public int Fees { get; set; }
        public DateTime StartDate { get; set; }

        private readonly ICourseService _courseService;
        private readonly IMapper _mapper;
        public CreateCourseModel()
        {
            _mapper = Startup.AutofacContainer.Resolve<IMapper>();
            _courseService = Startup.AutofacContainer.Resolve<ICourseService>();
        }
        public CreateCourseModel(ICourseService courseService, IMapper mapper)
        {
            _mapper = mapper;
            _courseService = courseService;
        }

        internal void CreateCourse()
        {
            var course = _mapper.Map<Course>(this);

            //var course = new Course();
            //_mapper.Map(this,course);

            _courseService.CreateCourse(course);
        }
    }
}
