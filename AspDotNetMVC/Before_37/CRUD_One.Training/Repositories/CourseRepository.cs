using CRUD_One.Data;
using CRUD_One.Training.Contexts;
using CRUD_One.Training.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUD_One.Training.Repositories
{
    public class CourseRepository : Repository<Course, int>, ICourseRepository
    {
        public CourseRepository(ITrainingDbContext dbContext)
            : base((DbContext)dbContext)
        {

        }
    }
}
