using ExamTimeChallengeTwo.Training.BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamTimeChallengeTwo.Training.Services
{
    public interface IStudentService
    {
        void CreateStudent(Student student);
        (IList<Student> records, int total, int totalDisplay) GetStudentData(int pageIndex, 
            int pageSize, string searchText, string sortText);
    }
}
