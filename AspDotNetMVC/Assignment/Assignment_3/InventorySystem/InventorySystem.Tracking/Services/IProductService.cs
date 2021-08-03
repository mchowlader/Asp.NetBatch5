using InventorySystem.Tracking.BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventorySystem.Tracking.Services
{
    public interface IProductService
    {
        void CreateProduct(Product product);
        (IList<Product> records, int total, int totalDisplay) GetProduct(int pageIndex, int pageSize, 
            string searchText, string sortText);
        Product GetProduct(int id);
        void UpdateProduct(Product product);
        void DeleteProduct(int id);
    }
}
