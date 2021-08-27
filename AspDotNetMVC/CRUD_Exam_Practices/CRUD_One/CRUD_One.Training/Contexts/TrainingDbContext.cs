using CRUD_One.Training.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUD_One.Training.Contexts
{
    public class TrainingDbContext : DbContext, ITrainingDbContext
    {
        private readonly string _connectionString;
        private readonly string _migrationsAssemblyName;
        public TrainingDbContext(string connectionString, string migrationsAssemblyName)
        {
            _connectionString = connectionString;
            _migrationsAssemblyName = migrationsAssemblyName;

        }

        protected override void OnConfiguring(DbContextOptionsBuilder dbContextOptionsBuilder )
        {
            dbContextOptionsBuilder.UseSqlServer(_connectionString, 
                x => x.MigrationsAssembly(_migrationsAssemblyName));

            base.OnConfiguring(dbContextOptionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Course> Courses { get; set; } 
    }
}
