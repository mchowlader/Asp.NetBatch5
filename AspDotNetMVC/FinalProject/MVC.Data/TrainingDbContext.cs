using Microsoft.EntityFrameworkCore;
using System;

namespace MVC.Data
{
    public class TrainingDbContext : DbContext
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
            if(!dbContextOptionsBuilder.IsConfigured)
            {
                dbContextOptionsBuilder.UseSqlServer(
                    _connectionString,
                    m => m.MigrationsAssembly(_migrationsAssemblyName));
            }
            base.OnConfiguring(dbContextOptionsBuilder);
        }

        public DbSet<Course> Course { get; set; }

        public DbSet<Student> Student { get; set; }

        public DbSet<Topic> Topic { get; set; }
    }
}
