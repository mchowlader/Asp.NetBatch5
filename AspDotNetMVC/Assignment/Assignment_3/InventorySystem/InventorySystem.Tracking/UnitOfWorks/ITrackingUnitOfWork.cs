using InventorySystem.Data;
using InventorySystem.Tracking.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventorySystem.Tracking.UnitOfWorks
{
    public interface ITrackingUnitOfWork : IUnitOfWork
    {
        IProductRepository Products { get; }
        IStockRepository Stocks { get; }
    }
}
