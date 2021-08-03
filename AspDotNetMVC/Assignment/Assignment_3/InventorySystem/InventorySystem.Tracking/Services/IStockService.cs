using nventorySystem.Tracking.BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventorySystem.Tracking.Services
{
    public interface IStockService
    {
        void CreateStock(Stock stock);
        (IList<Stock> records, int total, int totalDisplay) GetStocks(int pageIndex, 
            int pageSize, string searchText, string sortText);
        Stock GetStocks(int id);
        void UpdateStock(Stock stock);
        void DeleteStock(int id);
    }
}
