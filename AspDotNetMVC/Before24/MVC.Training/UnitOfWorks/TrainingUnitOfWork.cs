using MVC.Data;
using MVC.Training.Contexts;
using MVC.Training.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC.Training.UnitOfWorks
{
    public class TrainingUnitOfWork : UnitofWork, ITrainingUnitOfWork
    {
        
        public IStudentRepository Students { get; set; }
        public ICourseRepository Courses { get; set; }

        public TrainingUnitOfWork(TrainingDbContext context,
            ICourseRepository courses,
            IStudentRepository students)
            : base(context) 
        {
            Courses = courses;
            Students = students;
        }

    }
}
