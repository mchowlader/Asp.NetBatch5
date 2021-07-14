using MVC.Data;
using MVC.Training.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC.Training.UnitOfWorks
{
    public interface ITrainingUnitOfWork : IUnitofWork
    {
        //IStudentRepository Students { get; set; }
        ICourseRepository Courses { get; set; }
    }
}
