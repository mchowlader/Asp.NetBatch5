using MVC.Data;
using MVC.Training.Repositories;
using MVC.Traning.Entities;

namespace MVC.Training.UnitOfWorks
{
    public interface ITrainingUnitOfWork : IUnitOfWork
    {
        ICourseRepository CourseRepository { get; }
        IStudentRepository StudentRepository { get; }
    }
}