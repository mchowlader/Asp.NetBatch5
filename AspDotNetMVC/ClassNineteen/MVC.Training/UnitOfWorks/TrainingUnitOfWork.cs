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
        public IRepository<Student> Students { get; private set; }

        public IRepository<Course> Courses { get; private set; }

        public TrainingUnitOfWork(TrainingDbContext Context) : base(Context)
        {
            Students = new StudentRepository(Context);

            Courses = new CourseRepository(Context);
        }
    }
}
