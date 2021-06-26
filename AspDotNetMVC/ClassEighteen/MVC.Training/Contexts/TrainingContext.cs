using Microsoft.EntityFrameworkCore;
using MVC.Training.Entities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC.Training.Contexts
{
    public class TrainingContext : DbContext
    {
        private string  _sqlConnection;
        private string _migrationAssemblyName;

        public TrainingContext(string sqlConnection, string migrationsAssemblyName)
        {
            _sqlConnection = sqlConnection;
            _migrationAssemblyName = migrationsAssemblyName;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder dbContextOptionsBuilder)
        {
            if (!dbContextOptionsBuilder.IsConfigured)
            {
                dbContextOptionsBuilder.UseSqlServer(
                    _sqlConnection,
                    m => m.MigrationsAssembly(_migrationAssemblyName));
            }
            base.OnConfiguring(dbContextOptionsBuilder);
        }

        public DbSet<Course> Course { get; set; }
        public DbSet<Student> Student { get; set; }
    }
}
