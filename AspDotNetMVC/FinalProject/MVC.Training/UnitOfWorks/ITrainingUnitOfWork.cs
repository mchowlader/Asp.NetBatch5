using MVC.Data;
using MVC.Traning.Entities;

namespace MVC.Training.UnitOfWorks
{
    public interface ITrainingUnitOfWork : IUnitOfWork
    {
        IRepository<Course> courseRepository { get; }
        IRepository<Student> studentRepository { get; }
    }
}