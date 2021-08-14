using System;
using System.ComponentModel.DataAnnotations;
using AttendanceSystem.Present.BusinessObjects;
using AttendanceSystem.Present.Services;
using Autofac;

namespace AttendanceSystem.Web.Areas.Education.Models
{
    public class EditStudentModel
    {
        [Required]
        public int? Id { get; set; }
        [Required, MaxLength(100, ErrorMessage = "charecter length should be less than 100")]
        public string Name { get; set; }
        [Required, Range(1, 100000)]
        public int? StudentRollNumber { get; set; }

        private readonly IStudentService _studentService;

        public EditStudentModel()
        {
            _studentService = Startup.AutofacContainer.Resolve<IStudentService>();
        }
        public EditStudentModel(IStudentService studentService)
        {
            _studentService = studentService;
        }

        internal void Update()
        {
            var student = new Student()
            {
                Id = Id.HasValue ? Id.Value : 0,
                Name = Name,
                StudentRollNumber = StudentRollNumber.HasValue ? StudentRollNumber.Value : 0,
            };
            _studentService.UpdateStudent(student);
        }

        internal void LoadStudentData(int id)
        {
            var studnet = _studentService.GetStudents(id);

            Id = studnet?.Id;
            Name = studnet?.Name;
            StudentRollNumber = studnet?.StudentRollNumber;
            
        }
    }
}
