using Microsoft.EntityFrameworkCore;
using MVC.Training.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC.Training.Contexts
{
    public class TrainingDbContext : DbContext, ITrainingDbContext
    {
        private readonly string _connectionString;
        private readonly string _migrationAssemblyName;

        public TrainingDbContext(string connectionString, string migrationAssemblyName)
        {
            _connectionString = connectionString;
            _migrationAssemblyName = migrationAssemblyName;
        }
        protected override void OnConfiguring(DbContextOptionsBuilder dbContextOptionsBuilder)
        {
            dbContextOptionsBuilder.UseSqlServer(_connectionString,
                x => x.MigrationsAssembly(_migrationAssemblyName));

            base.OnConfiguring(dbContextOptionsBuilder);
        }

        public DbSet<Student> Students { get; set; }
        public DbSet<Course> Courses { get; set; }
    }
}
