using MVC.Training.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Autofac;
using MVC.Training.BusinessObjects;

namespace MVC.Web.Areas.Admin.Models
{
    public class CreateStudentModel
    {
        public string Name { get; set; }
        public string Department { get; set; }
        public DateTime DateOfBirth { get; set; }

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
                Department = Department,
                DateOfBirth = DateOfBirth
            };
            _studentService.CreateStudent(student);
        }
    }
}
