using InventorySystem.Data;
using InventorySystem.Tracking.Contexts;
using InventorySystem.Tracking.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventorySystem.Tracking.UnitOfWorks
{
    public class TrackingUnitOfWork : UnitOfWork, ITrackingUnitOfWork
    {
        public IProductRepository Products { get; private set; }
        public IStockRepository Stocks { get; private set; }
        public TrackingUnitOfWork(ITrackinDbContext dbContext,
            IProductRepository productRepository,
            IStockRepository stockRepository)
            : base((DbContext)dbContext)
        {
            Products = productRepository;
            Stocks = stockRepository;
        }

    }
}
