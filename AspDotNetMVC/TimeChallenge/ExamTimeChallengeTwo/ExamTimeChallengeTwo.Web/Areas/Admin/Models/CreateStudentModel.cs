using AutoMapper;
using ExamTimeChallengeTwo.Training.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Autofac;
using ExamTimeChallengeTwo.Training.BusinessObjects;

namespace ExamTimeChallengeTwo.Web.Areas.Admin.Models
{
    public class CreateStudentModel
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public DateTime DateOfBirth { get; set; }

        private readonly IStudentService _studentService;
        private readonly IMapper _mapper;

        public CreateStudentModel()
        {
            _studentService = Startup.AutofacContainer.Resolve<IStudentService>();
            _mapper = Startup.AutofacContainer.Resolve<IMapper>();

        }
        public CreateStudentModel(IMapper mapper, IStudentService studentService)
        {
            _mapper = mapper;
            _studentService = studentService;
        }

        internal void CreateStudent()
        {
            var student = _mapper.Map<Student>(this);
            _studentService.CreateStudent(student);
        }
    }
}
