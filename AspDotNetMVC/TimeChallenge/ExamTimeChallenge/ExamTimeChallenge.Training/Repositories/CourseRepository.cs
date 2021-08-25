using ExamTimeChallenge.Data;
using ExamTimeChallenge.Training.Contexts;
using ExamTimeChallenge.Training.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamTimeChallenge.Training.Repositories
{
    public class CourseRepository : Repository<Course, int>, ICourseRepository
    {
        public CourseRepository(ITrainingDbContext trainingDbContext)
            : base((DbContext)trainingDbContext)
        {

        }
    }
}
