using DemoProject.Training.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Autofac;
using DemoProject.Training.BusinessObjects;

namespace DemoProject.Areas.Admin.Models
{
    public class CreateStudentModel
    {
        public string Name { get; set; }
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
        internal void CerateStudent()
        {
            var student = new Student() 
            {
                Name = Name,
                DateOfBirth = DateOfBirth
            };

            _studentService.StudentRegistration(student);
        }
    }
}
