using MVC.Training.BusinessObjects;
using MVC.Training.Services;
using MVC.Traning.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Autofac;

namespace MVC.Web.Areas.Admin.Models
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
            Courses = _courseService.GetAllCourses();
        }
      
    }
}
