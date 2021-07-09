using DemoProject.Data;
using DemoProject.Training.Contexts;
using DemoProject.Training.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoProject.Training.Repositories
{
    public class CourseRepository : Repository<Course, int>, ICourseRepository
    {
        public CourseRepository(TrainingDbContext context)
            : base(context)
        {
            
        }

    }
}
