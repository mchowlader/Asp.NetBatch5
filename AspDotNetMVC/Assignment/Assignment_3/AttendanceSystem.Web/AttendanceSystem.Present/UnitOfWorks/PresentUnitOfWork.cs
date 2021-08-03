using AttendanceSystem.Data;
using AttendanceSystem.Present.Contexts;
using AttendanceSystem.Present.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AttendanceSystem.Present.UnitOfWorks
{
    public class PresentUnitOfWork : UnitOfWork, IPresentUnitOfWork
    {
        public IStudentRepository Students { get; private set; }
        public IAttendanceRepository Attendances { get; private set; }

        public PresentUnitOfWork(IPresentDbContext dbContext, 
            IStudentRepository studentRepository,
            IAttendanceRepository attendanceRepository)
            : base((DbContext)dbContext)
        {
            Students = studentRepository;
            Attendances = attendanceRepository;
        }

        
    }
}
