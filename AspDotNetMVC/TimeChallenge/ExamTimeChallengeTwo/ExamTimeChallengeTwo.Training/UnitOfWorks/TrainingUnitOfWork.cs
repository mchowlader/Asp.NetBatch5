using ExamTimeChallengeTwo.Data;
using ExamTimeChallengeTwo.Training.Contexts;
using ExamTimeChallengeTwo.Training.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamTimeChallengeTwo.Training.UnitOfWorks
{
    public class TrainingUnitOfWork : UnitOfWork, ITrainingUnitOfWork
    {
        public IStudentRepository Students { get; private set; }

        public TrainingUnitOfWork(ITrainingDbContext trainingDbContext,
            IStudentRepository studentRepository)
            :base((DbContext)trainingDbContext)
        {
            Students = studentRepository;
        }

    }
}
