using MVC.Data;
using MVC.Traning.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC.Training.UnitOfWorks
{
    public class AdoNetTrainingUnitOfWorks : ITrainingUnitOfWork
    {
        public IRepository<Course> Courses => throw new NotImplementedException();

        public IRepository<Student> Students => throw new NotImplementedException();

        public void Save()
        {
            throw new NotImplementedException();
        }
    }
}
