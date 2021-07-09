using DemoProject.Training.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Autofac;
using DemoProject.Training.BusinessObjects;

namespace DemoProject.Areas.Admin.Models
{
    public class CourseListModel 
    {

        private readonly ICourseService _courseService;
        public IList<Course> Courses { get; set; }
        public CourseListModel()
        {
            _courseService = Startup.AutofacContainer.Resolve<ICourseService>();
        }
        public CourseListModel(ICourseService courseService)
        {
            _courseService = courseService;
        }

        public void LoadModelData()
        {
            Courses = _courseService.GetAllCourse();
        }
    }
}
