using MVC.Training.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Autofac;
using MVC.Training.BusinessObjects;

namespace MVC.Web.Areas.Admin.Models
{
    public class StudentListModelcs
    {
        private readonly IStudentService _studentService;
        public StudentListModelcs()
        {
            _studentService = Startup.AutofacContainer.Resolve<IStudentService>();
        }
        public StudentListModelcs(IStudentService studentService)
        {
            _studentService = studentService;
        }
        public IList<Student> Students { get; set; }
        internal void LoadStudentDataModel()
        {
            Students = _studentService.GetStudentList();
        }
    }
}
