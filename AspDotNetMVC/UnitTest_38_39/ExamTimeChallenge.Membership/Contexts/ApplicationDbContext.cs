using ExamTimeChallenge.Membership.Entities;
using ExamTimeChallenge.Membership.Seeds;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace ExamTimeChallenge.Membership.Contexts
{
    public class ApplicationDbContext : IdentityDbContext< ApplicationUser,
        Role, Guid, UserClaim, UserRole, UserLogin, RoleClaim, UserToken>, IApplicationDbContext
    {
        private readonly string _connectionString;
        private readonly string _migrationsAssemblyName;
        public ApplicationDbContext(string connectionString, string migrationsAssemblyName)
        {
            _connectionString = connectionString;
            _migrationsAssemblyName = migrationsAssemblyName;
        }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder dbContextOptionsBuilder)
        {
            if (!dbContextOptionsBuilder.IsConfigured)
            {
                dbContextOptionsBuilder.UseSqlServer(_connectionString,
                    x => x.MigrationsAssembly(_migrationsAssemblyName));
            }

            base.OnConfiguring(dbContextOptionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Role>()
                .HasData(DataSeed.Roles);

            base.OnModelCreating(builder);
        }
    }
}
