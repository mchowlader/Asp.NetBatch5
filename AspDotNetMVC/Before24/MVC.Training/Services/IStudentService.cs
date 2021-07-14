using MVC.Training.BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC.Training.Services
{
    public interface IStudentService
    {
        void CreateStudent(Student student);
        IList<Student> GetStudentList();
    }
}
