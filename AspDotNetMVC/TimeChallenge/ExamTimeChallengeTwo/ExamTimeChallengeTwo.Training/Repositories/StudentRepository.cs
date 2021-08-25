using ExamTimeChallengeTwo.Data;
using ExamTimeChallengeTwo.Training.Contexts;
using ExamTimeChallengeTwo.Training.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamTimeChallengeTwo.Training.Repositories
{
    public class StudentRepository : Repository<Student, int>, IStudentRepository
    {
        public StudentRepository(ITrainingDbContext trainingDbContext)
            : base((DbContext)trainingDbContext)
        {

        }
    }
}
