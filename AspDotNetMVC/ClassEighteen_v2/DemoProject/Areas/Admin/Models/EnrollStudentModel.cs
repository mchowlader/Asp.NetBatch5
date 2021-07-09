using DemoProject.Training.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Autofac;
using DemoProject.Training.BusinessObjects;

namespace DemoProject.Areas.Admin.Models
{
    public class EnrollStudentModel
    {
        public string CourseName { get; set; }
        public int StudentId { get; set; }
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
            var courses = _courseService.GetAllCourse();
            var selectCourses = courses.Where(x => x.Titel == CourseName).FirstOrDefault();
            var student = new Student
            {
                Id = StudentId,
                Name = "MIthun CH",
                DateOfBirth = DateTime.Now

            };
            _courseService.EnrollStudent(selectCourses, student);
        }
    }
}
