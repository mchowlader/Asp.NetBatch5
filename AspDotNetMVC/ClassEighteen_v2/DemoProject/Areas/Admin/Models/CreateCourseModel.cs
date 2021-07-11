using DemoProject.Training.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Autofac;
using DemoProject.Training.BusinessObjects;

namespace DemoProject.Areas.Admin.Models
{
    public class CreateCourseModel
    {
        public string Title { get; set; }
        public int Fees { get; set; }
        public DateTime Startdate { get; set; }

        private readonly ICourseService _courseService;
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
                Titel = Title,
                Fees = Fees,
                StartDate = Startdate
            };

            _courseService.CreateCourse(course);
        }
    }
}
