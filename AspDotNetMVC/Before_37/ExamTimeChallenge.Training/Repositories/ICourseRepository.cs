using ExamTimeChallenge.Data;
using ExamTimeChallenge.Training.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamTimeChallenge.Training.Repositories
{
    public interface ICourseRepository : IRepository<Course, int>
    {
    }
}
