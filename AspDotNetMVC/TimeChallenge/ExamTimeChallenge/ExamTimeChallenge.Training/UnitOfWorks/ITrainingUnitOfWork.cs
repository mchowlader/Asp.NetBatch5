using ExamTimeChallenge.Data;
using ExamTimeChallenge.Training.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamTimeChallenge.Training.UnitOfWorks
{
    public interface ITrainingUnitOfWork : IUnitOfWork
    {
        ICourseRepository Courses { get; }
    }
}
