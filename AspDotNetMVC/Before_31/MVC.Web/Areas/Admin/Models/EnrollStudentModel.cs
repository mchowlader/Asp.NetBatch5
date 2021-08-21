using MVC.Training.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Autofac;
using MVC.Training.BusinessObjects;

namespace MVC.Web.Areas.Admin.Models
{
    public class EnrollStudentModel
    {
        public string CourseName { get; set; }
        public int StudentId { get; set; }
        public int Id { get; set; }
        public string Name { get; set; }

        private readonly ICourseService _courseService;
        public EnrollStudentModel()
        {
            _courseService = Startup.AutofacContainer.Resolve<ICourseService>();
        }
        public EnrollStudentModel(ICourseService courseService)
        {
            _courseService = courseService;
        }

        public void EnrollStudent()
        {
            var courses = _courseService.GetAllCourses();
            var selectedCourse = courses.Where(m => m.Title == CourseName).FirstOrDefault();

            var student = new Student 
            {
                Id =StudentId,
                DateOfBirth = DateTime.Now,
                Name = "Mithun CH"
            };

            _courseService.EnrollStudent(selectedCourse, student);
        }
    }
}
