using InventorySystem.Tracking.BusinessObjects;
using InventorySystem.Tracking.UnitOfWorks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventorySystem.Tracking.Services
{
    public class ProductService : IProductService
    {
        private readonly ITrackingUnitOfWork _trackingUnitOfWork;
        public ProductService(ITrackingUnitOfWork trackingUnitOfWork)
        {
            _trackingUnitOfWork = trackingUnitOfWork;
        }

        public void CreateProduct(Product product)
        {
            _trackingUnitOfWork.Products.Add(
                new Entities.Product()
                {
                    Name = product.Name,
                    Price = product.Price
                });
            _trackingUnitOfWork.Save();
        }

        public void DeleteProduct(int id)
        {
            _trackingUnitOfWork.Products.Remove(id);
            _trackingUnitOfWork.Save();
        }

        public (IList<Product> records, int total, int totalDisplay) GetProduct(int pageIndex, 
            int pageSize, string searchText, string sortText)
        {
            var productData = _trackingUnitOfWork.Products.GetDynamic(
                string.IsNullOrWhiteSpace(searchText)? null: x => x.Name.Contains(searchText),
                sortText, string.Empty, pageIndex, pageSize);

            var resultData = (from product in productData.data
                              select new Product()
                              {
                                  Id = product.Id,
                                  Name = product.Name,
                                  Price = product.Price
                              }).ToList();

            return (resultData, productData.total, productData.totalDisplay);

        }

        public Product GetProduct(int id)
        {
            var product = _trackingUnitOfWork.Products.GetById(id);

            return new Product()
            {
                Id = id,
                Name = product.Name,
                Price = product.Price
            };
        }

        public void UpdateProduct(Product product)
        {
            if (product == null)
                throw new InvalidOperationException();

            var productEntity = _trackingUnitOfWork.Products.GetById(product.Id);

            if(productEntity != null)
            {
                productEntity.Name = product.Name;
                productEntity.Price = product.Price;

                _trackingUnitOfWork.Save();
            }
        }
    }
}
