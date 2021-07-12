using DemoProject.Training.BusinessObjects;
using DemoProject.Training.UnitOfWorks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoProject.Training.Services
{
    public class StudentService : IStudentService
    {
        private readonly ITrainingUnitOfWork _trainingUnintOfWork;
        public StudentService(ITrainingUnitOfWork trainingUnintOfWork)
        {
            _trainingUnintOfWork = trainingUnintOfWork;
        }

        public IList<Student> GetAllStudentList()
        {
            var entities = _trainingUnintOfWork.Students.GetAll();
            var studentList = new List<Student>();
            foreach(var entity in entities)
            {
                var student = new Student() 
                { 
                    Name = entity.Name,
                    DateOfBirth = entity.DateOfBirth
                };
                studentList.Add(student);
            }
            return studentList;
        }

        public void StudentRegistration(Student student)
        {
            _trainingUnintOfWork.Students.Add
                (
                    new Entities.Student 
                    {
                         Name = student.Name,
                         DateOfBirth = student.DateOfBirth
                    }
                );
            _trainingUnintOfWork.Save();
        }
    }
}
