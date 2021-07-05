using Microsoft.EntityFrameworkCore;
using MVC.Data;
using MVC.Training.Repositories;
using MVC.Traning.Contexts;
using MVC.Traning.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC.Training.UnitOfWorks
{
    public class TrainingUnitOfWork : UnitOfWork, ITrainingUnitOfWork
    {
        public IRepository<Student> studentRepository { get; private set; }
        public IRepository<Course> courseRepository { get; private set; }
        public TrainingUnitOfWork(TrainingDbContext context)
            : base(context)
        {
            studentRepository = new StudentRepository(context);

            courseRepository = new CourseRepository(context);
        }
    }
}
