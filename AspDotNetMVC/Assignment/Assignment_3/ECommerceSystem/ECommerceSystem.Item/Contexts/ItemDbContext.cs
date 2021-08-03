using ECommerceSystem.Item.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceSystem.Item.Contexts
{
    public class ItemDbContext : DbContext, IItemDbContext
    {
        private readonly string _connectionString;
        private readonly string _migrstionAssemblyName;
        public ItemDbContext(string connectionString, string migrstionAssemblyName)
        {
            _connectionString = connectionString;
            _migrstionAssemblyName = migrstionAssemblyName;
        }

        protected override void OnConfiguring( DbContextOptionsBuilder dbContextOptionsBuilder)
        {
            dbContextOptionsBuilder.UseSqlServer(_connectionString, 
                x => x.MigrationsAssembly(_migrstionAssemblyName));

            base.OnConfiguring(dbContextOptionsBuilder);
        }

        public DbSet<Product> Products { get; set; }
    }
}
