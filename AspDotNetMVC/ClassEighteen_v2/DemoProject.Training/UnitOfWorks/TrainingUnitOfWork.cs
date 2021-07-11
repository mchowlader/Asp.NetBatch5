using DemoProject.Data;
using DemoProject.Training.Contexts;
using DemoProject.Training.Entities;
using DemoProject.Training.Repositories;
using Microsoft.EntityFrameworkCore;

namespace DemoProject.Training.UnitOfWorks
{
    public class TrainingUnitOfWork : UnitOfWork, ITrainingUnitOfWork
    {
        public IStudentRepository Students { get; set; }
        public ICourseRepository Courses { get; set; }
        public TrainingUnitOfWork(TrainingDbContext context,
            IStudentRepository studentRepository, 
            ICourseRepository courseRepository): base(context)
        {
            Students = studentRepository;
            Courses = courseRepository;
        }
    }
}
