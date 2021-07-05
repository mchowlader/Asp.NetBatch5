using MVC.Training.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Autofac;
using MVC.Training.BusinessObjects;

namespace MVC.Web.Areas.Admin.Models
{
    public class CreateCourseModel
    {
        public string Titel { get; set; }
        public int Fees { get; set; }
        public DateTime StartDate { get; set; }

        private ICourseService _courseService;
        public CreateCourseModel()
        {
            _courseService = Startup.AutofacContainer.Resolve<ICourseService>();
        }
        public CreateCourseModel(ICourseService courseService)
        {
            _courseService = courseService;
        }

        internal void CreateCourse()
        {
            var course = new Course() 
            {
                Title = Titel,
                Fees = Fees,
                StartDate = StartDate
            };

            _courseService.CreateCourse(course);
        }
    }
}
