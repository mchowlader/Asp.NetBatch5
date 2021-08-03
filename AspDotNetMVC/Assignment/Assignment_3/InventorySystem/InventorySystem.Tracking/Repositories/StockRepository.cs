using InventorySystem.Data;
using InventorySystem.Tracking.Contexts;
using InventorySystem.Tracking.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventorySystem.Tracking.Repositories
{
    public class StockRepository : Repository<Stock, int>, IStockRepository
    {
        public StockRepository(ITrackinDbContext dbContext)
            : base((DbContext)dbContext)
        {

        }
    }
}
