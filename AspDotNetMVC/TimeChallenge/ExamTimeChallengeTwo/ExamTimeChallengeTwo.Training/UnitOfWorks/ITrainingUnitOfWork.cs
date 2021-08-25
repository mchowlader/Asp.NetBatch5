using ExamTimeChallengeTwo.Data;
using ExamTimeChallengeTwo.Training.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamTimeChallengeTwo.Training.UnitOfWorks
{
    public interface ITrainingUnitOfWork : IUnitOfWork
    {
        IStudentRepository Students { get;}
    }
}
