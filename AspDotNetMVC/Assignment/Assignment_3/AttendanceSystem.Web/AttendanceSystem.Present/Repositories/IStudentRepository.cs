using AttendanceSystem.Data;
using AttendanceSystem.Present.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AttendanceSystem.Present.Repositories
{
    public interface IStudentRepository : IRepository<Student, int>
    {
    }
}
