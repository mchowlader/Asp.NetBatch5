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
        public IStudentRepository StudentRepository { get; private set; }
        public ICourseRepository CourseRepository { get; private set; }

        public TrainingUnitOfWork(TrainingDbContext context,
            IStudentRepository studentRepository,
            ICourseRepository courseRepository): base(context)
        {
            StudentRepository = studentRepository;
            CourseRepository = courseRepository;
        }
    }
}
