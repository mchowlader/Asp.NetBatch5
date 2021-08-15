using SchoolManagement.Data;
using SchoolManagement.Present.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagement.Present.Repositories
{
    public interface IStudentRepository : IRepository<Student, int>
    {
    }
}
