using MVC.Training.BusinessObjects;
using MVC.Training.UnitOfWorks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC.Training.Services
{
    public class StudentService : IStudentService
    {
        private readonly ITrainingUnitOfWork _trainingUnitOfWork;

        public StudentService(ITrainingUnitOfWork trainingUnitOfWork)
        {
            _trainingUnitOfWork = trainingUnitOfWork;
        }
        public void CreateStudent(Student student)
        {
            _trainingUnitOfWork.Students.Add
                (
                    new Entities.Student
                    {
                        Name = student.Name,
                        Department = student.Department,
                        DateOfBirth = student.DateOfBirth
                    }
                );
            _trainingUnitOfWork.save();
        }

        public IList<Student> GetStudentList()
        {
            var StudentsList = new List<Student>();
            var studentList = _trainingUnitOfWork.Students.GetAll();
            foreach(var entity in studentList)
            {
                var student = new Student()
                {
                    Name = entity.Name,
                    Department = entity.Department,
                    DateOfBirth = entity.DateOfBirth
                };

                StudentsList.Add(student);
            }
            return StudentsList;
        }

    }
}
