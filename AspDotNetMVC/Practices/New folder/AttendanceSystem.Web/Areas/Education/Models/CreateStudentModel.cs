using AttendanceSystem.Present.Services;
using System;
using Autofac;
using System.ComponentModel.DataAnnotations;
using AttendanceSystem.Present.BusinessObjects;

namespace AttendanceSystem.Web.Areas.Education.Models
{
    public class CreateStudentModel
    {
        [Required, MaxLength(100,ErrorMessage = "charecter length should be less than 100")]
        public string Name { get; set; }
        [Required, Range(1,100000)]
        public int StudentRollNumber { get; set; }

        private readonly IStudentService _studentService;

        public CreateStudentModel()
        {
            _studentService = Startup.AutofacContainer.Resolve<IStudentService>();
        }
        public CreateStudentModel(IStudentService studentService)
        {
            _studentService = studentService;
        }

        internal void CreateStudent()
        {
            var student = new Student()
            { 
                Name = Name,
                StudentRollNumber = StudentRollNumber
            };
            _studentService.CreateStudent(student);
        }
    }
}
