using MVC.Training.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Autofac;
using MVC.Training.BusinessObjects;

namespace MVC.Web.Areas.Admin.Models
{
    public class CourseListModel
    {
        public IList<Course> Courses { get; set; }

        private readonly ICourseService _courseService;
        public CourseListModel()
        {
            _courseService = Startup.AutofacContainer.Resolve<ICourseService>();
        }
        public CourseListModel(ICourseService courseService)
        {
            _courseService = courseService;
        }
        internal void LoadModelData()
        {
            Courses = _courseService.GetAllCourses();
        }
    }
}
