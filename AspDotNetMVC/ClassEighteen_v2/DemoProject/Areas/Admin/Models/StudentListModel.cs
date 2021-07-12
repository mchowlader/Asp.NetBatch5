using DemoProject.Training.BusinessObjects;
using DemoProject.Training.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Autofac;

namespace DemoProject.Areas.Admin.Models
{
    public class StudentListModel
    {
        private readonly IStudentService _studentService;
        public StudentListModel()
        {
            _studentService = Startup.AutofacContainer.Resolve<IStudentService>();
        }
        public StudentListModel(IStudentService studentService)
        {
            _studentService = studentService;
        }
        public IList<Student> StudentsList { get; set; }  
        internal void LoadModelStudentData()
        {
           StudentsList = _studentService.GetAllStudentList();
        }
    }
}
