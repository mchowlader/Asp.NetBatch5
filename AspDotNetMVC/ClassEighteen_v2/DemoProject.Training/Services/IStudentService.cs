using DemoProject.Training.BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoProject.Training.Services
{
    public interface IStudentService
    {
        void StudentRegistration(Student student);
        IList<Student> GetAllStudentList();
    }
}
