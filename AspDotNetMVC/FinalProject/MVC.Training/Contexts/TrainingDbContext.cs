using Microsoft.EntityFrameworkCore;
using MVC.Traning.Entities;
using System;

namespace MVC.Traning.Contexts
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
        public DbSet<Course> Courses { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Topic> Topics { get; set; }
    }
}
