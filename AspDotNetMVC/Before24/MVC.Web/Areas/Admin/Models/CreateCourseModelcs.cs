using MVC.Training.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Autofac;
using MVC.Training.BusinessObjects;

namespace MVC.Web.Areas.Admin.Models
{
    public class CreateCourseModelcs
    {
        public string Title { get; set; }
        public int Fees { get; set; }
        public DateTime StartDate { get; set; }

        private readonly ICourseService _courseService; 
        public CreateCourseModelcs()
        {
            _courseService = Startup.AutofacContainer.Resolve<ICourseService>();
        }
        public CreateCourseModelcs(ICourseService courseService)
        {
            _courseService = courseService;
        }
        internal void CreateCourse()
        {
            var course = new Course() 
            {
                Title = Title,
                Fees = Fees,
                StartDate = StartDate
            };
            _courseService.CreateCourse(course);
        }
    }
}
