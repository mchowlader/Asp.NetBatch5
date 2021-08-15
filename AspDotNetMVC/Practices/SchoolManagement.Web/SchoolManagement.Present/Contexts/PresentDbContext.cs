using Microsoft.EntityFrameworkCore;
using SchoolManagement.Present.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagement.Present.Contexts
{
    public class PresentDbContext : DbContext, IPresentDbContext
    {
        private readonly string _connectionString;
        private readonly string _migrationsAssemblyName;
        public PresentDbContext(string connectionString, string migrationsAssemblyName)
        {
            _connectionString = connectionString;
            _migrationsAssemblyName = migrationsAssemblyName;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder dbContextOptionsBuilder)
        {
            if (!dbContextOptionsBuilder.IsConfigured)
            {
                dbContextOptionsBuilder.UseSqlServer(
                    _connectionString,
                    m => m.MigrationsAssembly(_migrationsAssemblyName));
            }

            base.OnConfiguring(dbContextOptionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Course>()
                .HasMany(x => x.Topics)
                .WithOne(x => x.Course);

            modelBuilder.Entity<CourseStudents>()
                .HasKey(cs => new { cs.StudentId, cs.CourseId });

            modelBuilder.Entity<CourseStudents>()
                .HasOne(cs => cs.Course)
                .WithMany(c => c.EnrolledStudent)
                .HasForeignKey(cs => cs.CourseId);

            modelBuilder.Entity<CourseStudents>()
                .HasOne(cs => cs.Student)
                .WithMany(s => s.EnrolledCourses)
                .HasForeignKey(sc => sc.StudentId);

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Course> Courses { get; set; }
        public DbSet<Topic> Topics { get; set; }
        public DbSet<Student> Students { get; set; }
    }
}
