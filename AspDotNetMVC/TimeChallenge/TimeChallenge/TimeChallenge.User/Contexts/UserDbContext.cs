using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EO = TimeChallenge.User.Entities;

namespace TimeChallenge.User.Contexts
{
    public class UserDbContext : DbContext, IUserDbContext
    {

        private readonly string _connectionString;
        private readonly string _migrationsAssemblyName;

        public UserDbContext(string connectionString, string migrationsAssemblyName)
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

        public DbSet<EO.User> Users { get; set; }
        public DbSet<EO.Photo> Photos { get; set; }
    }
}
