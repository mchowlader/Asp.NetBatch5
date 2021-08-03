using AttendanceSystem.Data;
using AttendanceSystem.Present.Contexts;
using AttendanceSystem.Present.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AttendanceSystem.Present.Repositories
{
    public class AttendanceRepository : Repository<Attendance, int>, IAttendanceRepository
    {
        public AttendanceRepository(IPresentDbContext dbContext)
            : base((DbContext)dbContext)
        {

        }
    }
}
