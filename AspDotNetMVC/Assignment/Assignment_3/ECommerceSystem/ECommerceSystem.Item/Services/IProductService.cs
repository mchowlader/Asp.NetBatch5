using ECommerceSystem.Item.BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceSystem.Item.Services
{
    public interface IProductService
    {
        void CreateProduct(Product product);
        (IList<Product> records, int total, int totalDisplay) GetProducts(int pageIndex, int pageSize, 
            string searchText, string sortText);
        Product GetProducts(int id);
        void UpdateProduct(Product product);
        void DeleteProduct(int id);
    }
}
