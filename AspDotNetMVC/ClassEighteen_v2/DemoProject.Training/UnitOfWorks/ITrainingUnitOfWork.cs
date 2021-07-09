using DemoProject.Data;
using DemoProject.Training.Entities;
using DemoProject.Training.Repositories;

namespace DemoProject.Training.UnitOfWorks
{
    public interface ITrainingUnitOfWork : IUnitOfWork
    {
        IStudentRepository Students{ get; set; }
        ICourseRepository Courses { get; set; }
    }
}