using Autofac;
using MVC.Training.BusinessObjects;
using MVC.Training.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVC.Web.Areas.Admin.Models
{
    public class CourseListModel
    {

        private ICoursesService _coursesService;

        public IList<Course> Courses { get; set; }

        public CourseListModel()
        {
            _coursesService = Startup.AutofacContainer.Resolve<ICoursesService>();
        }

        public CourseListModel(ICoursesService coursesService)
        {
            _coursesService = coursesService;
        }

        public void LoadModelData()
        {
            Courses = _coursesService.GetAllCourses();

        }

    }
}
