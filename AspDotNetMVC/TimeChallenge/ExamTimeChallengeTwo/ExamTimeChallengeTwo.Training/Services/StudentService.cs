using AutoMapper;
using ExamTimeChallengeTwo.Training.BusinessObjects;
using ExamTimeChallengeTwo.Training.UnitOfWorks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamTimeChallengeTwo.Training.Services
{
    public class StudentService : IStudentService
    {
        private readonly ITrainingUnitOfWork _trainingUnitOfWork;
        private readonly IMapper _mapper;

        public StudentService(IMapper mapper, ITrainingUnitOfWork trainingUnitOfWork)
        {
            _mapper = mapper;
            _trainingUnitOfWork = trainingUnitOfWork;
        }

        public void CreateStudent(Student student)
        {
            _trainingUnitOfWork.Students.Add(
                _mapper.Map<Entities.Student>(student));
            _trainingUnitOfWork.Save();
        }

        public (IList<Student> records, int total, int totalDisplay) GetStudentData(int pageIndex, 
            int pageSize, string searchText, string sortText)
        {
            var restultStudent = _trainingUnitOfWork.Students.GetDynamic(string.IsNullOrWhiteSpace(searchText)? null:
                x => x.Name.Contains(searchText), sortText, string.Empty, pageIndex, pageSize);
            var studentData = (from data in restultStudent.data
                              select _mapper.Map<Student>(restultStudent)).ToList();

            return (studentData, restultStudent.total, restultStudent.totalDisplay); 

        }
    }
}
