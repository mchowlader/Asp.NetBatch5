using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment
{
    public class StudentCourseDbContext : DbContext
    {
        private string _connection;

        private string _assemblyName;

        public StudentCourseDbContext()
        {
            _connection = DbConnection.connectionString;
            _assemblyName = typeof(Program).Assembly.FullName;
        }


        protected override void OnConfiguring(DbContextOptionsBuilder dbContextOptionsBuilder)
        {
            if(!dbContextOptionsBuilder.IsConfigured)
            {
                dbContextOptionsBuilder.UseSqlServer(_connection, C => C.MigrationsAssembly(_assemblyName));
            }

            base.OnConfiguring(dbContextOptionsBuilder);
        }

        DbSet<StudentInfos> StudentInfos { get; set; }

        DbSet<Course> Courses { get; set; }
    }
}
