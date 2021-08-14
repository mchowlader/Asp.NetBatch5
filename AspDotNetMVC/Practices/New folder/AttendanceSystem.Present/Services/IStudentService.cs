using AttendanceSystem.Present.BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AttendanceSystem.Present.Services
{
    public interface IStudentService
    {
        void CreateStudent(Student student);
        (IList<Student> records, int total, int totalDisplay) GetStudents(int pageIndex, int pageSize, 
            string searchText, string sortText);
        Student GetStudents(int id);
        void UpdateStudent(Student student);
        void DeleteStudent(int id);
    }
}
