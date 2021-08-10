using Microsoft.EntityFrameworkCore;
using SocialMedia.Account.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMedia.Account.Contexts
{
    public class AccountDbContext : DbContext, IAccountDbContext
    {
        private readonly string _connectionString;
        private readonly string _migrationsAssemblyName;
        public AccountDbContext(string connectionString, string migrationsAssemblyName)
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

        public DbSet<User> Users { get; set; }
    }
}
