using InventorySystem.Tracking.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventorySystem.Tracking.Contexts
{
    public class TrackinDbContext : DbContext, ITrackinDbContext
    {
        private readonly string _connectionString;
        private readonly string _migrationsAssemblyName;

        public TrackinDbContext(string connectionString, string migrationsAssemblyName)
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

        protected override void OnModelCreating(ModelBuilder modelBuilder )
        {
            modelBuilder.Entity<Product>()
                .HasMany(x => x.Stocks)
                .WithOne(x => x.Product);

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Product> InventoryProducts { get; set; }
        public DbSet<Stock> Stocks { get; set; }

    }
}
