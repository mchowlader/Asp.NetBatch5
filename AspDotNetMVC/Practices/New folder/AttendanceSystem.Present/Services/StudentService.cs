using AttendanceSystem.Present.BusinessObjects;
using AttendanceSystem.Present.Exceptions;
using AttendanceSystem.Present.UnitOfWorks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AttendanceSystem.Present.Services
{
    public class StudentService : IStudentService
    {
        private readonly IPresentUnitOfWork _presentUnitOfWork;

        public StudentService(IPresentUnitOfWork presentUnitOfWork)
        {
            _presentUnitOfWork = presentUnitOfWork;
        }

        public void CreateStudent(Student student)
        {
            if (student == null)
                throw new InvalidOperationException("Student is missing");
            if(student.Name == null)
                throw new InvalidOperationException("Student Name is missing");
            if(student.StudentRollNumber.ToString() == null)
                throw new InvalidOperationException("Student Roll is missing");
            if (IsRollAlreadyUsed(student.StudentRollNumber))
                throw new DuplicateValueException("Roll already Exit");
            _presentUnitOfWork.Students.Add(
                new Entities.Student()
                {
                    Name = student.Name,
                    StudentRollNumber = student.StudentRollNumber
                });
            _presentUnitOfWork.Save();
        }
      
        public (IList<Student> records, int total, int totalDisplay) GetStudents(int pageIndex, int pageSize, 
            string searchText, string sortText)
        {
           var records = _presentUnitOfWork.Students.GetDynamic(
                string.IsNullOrWhiteSpace(searchText)? null: x => x.Name.Contains(searchText),
                sortText, string.Empty, pageIndex,pageSize);
            var result = (from record in records.data
                         select new Student() 
                         {
                            Name = record.Name,
                            StudentRollNumber = record.StudentRollNumber,
                            Id = record.Id
                         }).ToList();

            return (result, records.total, records.totalDisplay);
        }

        public Student GetStudents(int id)
        {
            var student = _presentUnitOfWork.Students.GetById(id);

            if (student == null) return null;

            return new Student()
            {
                Id = student.Id,
                Name = student.Name,
                StudentRollNumber = student.StudentRollNumber
            };
        }

        public void UpdateStudent(Student student)
        {
            if (student == null)
                throw new InvalidOperationException("student is missing");
            if (IsRollAlreadyUsed(student.Id, student.StudentRollNumber))
                throw new DuplicateValueException("Roll already exit");

            var studentEntity = _presentUnitOfWork.Students.GetById(student.Id);

            if (studentEntity != null)
            {
                studentEntity.Id = student.Id;
                studentEntity.Name = student.Name;
                studentEntity.StudentRollNumber = student.StudentRollNumber;

                _presentUnitOfWork.Save();
            }

            else
                throw new InvalidOperationException("Student couldn't find");
        }
        public void DeleteStudent(int id)
        {
            _presentUnitOfWork.Students.Remove(id);
            _presentUnitOfWork.Save();

        }


        private bool IsRollAlreadyUsed(int roll) => 
            _presentUnitOfWork.Students.GetCount(x => x.StudentRollNumber == roll) > 0;
        private bool IsRollAlreadyUsed(int id, int roll) =>
            _presentUnitOfWork.Students.GetCount(x => x.StudentRollNumber == roll && x.Id != id) > 0;
    }
}
