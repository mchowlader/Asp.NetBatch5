using MVC.Data;
using MVC.Traning.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC.Training.Repositories
{
    public interface ICourseRepository : IRepository<Course, int>
    {
    }
}
