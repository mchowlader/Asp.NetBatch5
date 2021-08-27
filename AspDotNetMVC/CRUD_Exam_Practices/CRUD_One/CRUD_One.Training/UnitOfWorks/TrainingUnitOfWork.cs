using CRUD_One.Data;
using CRUD_One.Training.Contexts;
using CRUD_One.Training.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUD_One.Training.UnitOfWorks
{
    public class TrainingUnitOfWork  : UnitOfWork, ITrainingUnitOfWork
    {
        public ICourseRepository Courses { get; private set; }

        public TrainingUnitOfWork(ITrainingDbContext dbContext,
            ICourseRepository courseRepository)
            : base((DbContext)dbContext)
        {
            Courses = courseRepository;
        }

    }
}
