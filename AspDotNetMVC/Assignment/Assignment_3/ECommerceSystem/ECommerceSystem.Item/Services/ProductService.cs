using ECommerceSystem.Item.BusinessObjects;
using ECommerceSystem.Item.Exceptions;
using ECommerceSystem.Item.UnitOfWorks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceSystem.Item.Services
{
    public class ProductService : IProductService
    {
        private readonly IItemUnitOfWork _itemUnitOfWork;

        public ProductService(IItemUnitOfWork itemUnitOfWork)
        {
            _itemUnitOfWork = itemUnitOfWork;
        }
        public void CreateProduct(Product product)
        {
            if (product == null)
                throw new InvalidParameterException("product was not found");
            if (product.Name == null)
                throw new InvalidOperationException("required product name");
            if (product.Price < 0)
                throw new InvalidOperationException("set vaid price");

            _itemUnitOfWork.Products.Add
                (
                    new Entities.Product()
                    {
                        Id = product.Id,
                        Name = product.Name,
                        Price = product.Price
                    }
                );
            _itemUnitOfWork.Save();
        }

        public void DeleteProduct(int id)
        {
            _itemUnitOfWork.Products.Remove(id);
            _itemUnitOfWork.Save();
        }

        public (IList<Product> records, int total, int totalDisplay) GetProducts(int pageIndex, int pageSize, 
            string searchText, string sortText)
        {
            var productData = _itemUnitOfWork.Products.GetDynamic(
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

        public Product GetProducts(int id)
        {
            var product = _itemUnitOfWork.Products.GetById(id);

            if (product == null) return null;

            return new Product()
            {
                Id = product.Id,
                Name = product.Name,
                Price = product.Price
            };
        }

        public void UpdateProduct(Product product)
        {
            if (product == null)
                throw new InvalidOperationException("Product is missing");

            if (IsNameAlreadyUsed(product.Name, product.Id))
                throw new DuplicateNameException("Product name already used in other Product");

            var productEntity = _itemUnitOfWork.Products.GetById(product.Id);

            if(productEntity != null)
            {
                productEntity.Name = product.Name;
                productEntity.Price = product.Price;

                _itemUnitOfWork.Save();
            }

            else
                throw new InvalidOperationException("Couldn't find product");
        }

        private bool IsNameAlreadyUsed(string name, int id) =>
            _itemUnitOfWork.Products.GetCount(x => x.Name == name && x.Id != id) > 0;
    }
}
