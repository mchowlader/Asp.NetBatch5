using Microsoft.EntityFrameworkCore;
using SocialNetwork.Account.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.Account.Contexts
{
    public class AccountDbContext : DbContext, IAccountDbContext
    {
        private readonly string _connectionString;
        private readonly string _migrationAssemblyName;

        public AccountDbContext(string connectionString, string migrationAssemblyName)
        {
            _connectionString = connectionString;
            _migrationAssemblyName = migrationAssemblyName;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder dbContextOptionsBuilder)
        {
            if(!dbContextOptionsBuilder.IsConfigured)
            {
                dbContextOptionsBuilder.UseSqlServer(_connectionString,
                x => x.MigrationsAssembly(_migrationAssemblyName));
            }

            base.OnConfiguring(dbContextOptionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Member>()
                .HasMany(x => x.Photos)
                .WithOne(x => x.Member);

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Member> Members { get; set; }
        public DbSet<Photo> Photos { get; set; }
    }
}
