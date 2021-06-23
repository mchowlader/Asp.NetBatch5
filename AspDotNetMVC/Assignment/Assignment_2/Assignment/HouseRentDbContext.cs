using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment
{
    public class HouseRentDbContext : DbContext
    {
        private string _connection;

        private string _assemblyName;


       
        public HouseRentDbContext()
        {
            _connection = DbConnection.connectionString;
            _assemblyName = typeof(Program).Assembly.FullName;
        }


        protected override void OnConfiguring(DbContextOptionsBuilder dbContextOptionsBuilder)
        {
            if(!dbContextOptionsBuilder.IsConfigured)
            {
                dbContextOptionsBuilder.UseSqlServer(_connection, C => C.MigrationsAssembly(_assemblyName));
            }

            base.OnConfiguring(dbContextOptionsBuilder);
        }

        DbSet<House> House { get; set; }

        DbSet<Room> Room { get; set; }
    }
}
