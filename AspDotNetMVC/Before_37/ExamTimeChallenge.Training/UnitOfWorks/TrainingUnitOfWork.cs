using ExamTimeChallenge.Data;
using ExamTimeChallenge.Training.Contexts;
using ExamTimeChallenge.Training.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamTimeChallenge.Training.UnitOfWorks
{
    public class TrainingUnitOfWork : UnitOfWork, ITrainingUnitOfWork
    {
        public ICourseRepository Courses { get; private set; }

        public TrainingUnitOfWork(ITrainingDbContext trainingDbContext, ICourseRepository courseRepository)
            : base((DbContext)trainingDbContext)
        {
            Courses = courseRepository;
        }

    }
}
