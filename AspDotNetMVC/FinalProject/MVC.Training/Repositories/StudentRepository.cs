using Microsoft.EntityFrameworkCore;
using MVC.Data;
using MVC.Traning.Contexts;
using MVC.Traning.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC.Training.Repositories
{
    public class StudentRepository : Repository<Student, int>, IStudentRepository
    {
        public StudentRepository(TrainingDbContext context)
            : base(context)
        {
            
        }

    }
}
