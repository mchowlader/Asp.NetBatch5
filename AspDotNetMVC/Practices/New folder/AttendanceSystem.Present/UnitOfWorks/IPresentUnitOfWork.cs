using AttendanceSystem.Data;
using AttendanceSystem.Present.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AttendanceSystem.Present.UnitOfWorks
{
    public interface IPresentUnitOfWork : IUnitOfWork
    {
        public IStudentRepository Students { get; }
        public IAttendanceRepository Attendances { get; }
    }
}
