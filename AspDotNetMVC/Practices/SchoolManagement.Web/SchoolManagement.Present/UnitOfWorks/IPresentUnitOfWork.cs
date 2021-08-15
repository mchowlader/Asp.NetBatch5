using SchoolManagement.Data;
using SchoolManagement.Present.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagement.Present.UnitOfWorks
{
    public interface IPresentUnitOfWork : IUnitOfWork
    {
        ITopicRepository Topics { get; }
        IStudentRepository Students { get; }
        ICourseRepository Courses { get; }
    }
}
