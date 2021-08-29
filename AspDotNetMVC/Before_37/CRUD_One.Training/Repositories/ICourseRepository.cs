using CRUD_One.Data;
using CRUD_One.Training.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUD_One.Training.Repositories
{
    public interface ICourseRepository : IRepository<Course,int>
    {
    }
}
