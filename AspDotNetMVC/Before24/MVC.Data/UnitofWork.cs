using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC.Data
{
    public class UnitofWork : IUnitofWork
    {
        private readonly DbContext _dbContext;

        public UnitofWork(DbContext dbContext) => _dbContext = dbContext;
        public void Dispose() => _dbContext.Dispose();
        public void save() => _dbContext.SaveChanges();
        
    }
}
