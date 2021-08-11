using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SocialMedia.Membership.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SocialMedia.Membership.Contexts
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser, Role, Guid,
        UserClaim, UserRole, UserLogin, RoleClaim, UserToken>, IApplicationDbContext
    {
        private readonly string _connectionString;
        private readonly string _migrationsAssemblyName;

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {

        }
        public ApplicationDbContext(string connectionString, string migrationsAssemblyName)
        {
            _connectionString = connectionString;
            _migrationsAssemblyName = migrationsAssemblyName;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder dbContextOptionsBuilder)
        {
            dbContextOptionsBuilder.UseSqlServer(_connectionString,
                x => x.MigrationsAssembly(_migrationsAssemblyName));

            base.OnConfiguring(dbContextOptionsBuilder);
        }
    }
}
