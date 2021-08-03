using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Autofac;
using ECommerceSystem.Item.BusinessObjects;
using ECommerceSystem.Item.Services;

namespace ECommerceSystem.Web.Areas.Admin.Models
{
    public class CreateProductModel
    {
        [Required, MaxLength(200, ErrorMessage = "Name less than should be 100")]
        public string Name { get; set; }
        [Required, Range(1, 1000000)]
        public int Price { get; set; }

        private readonly IProductService _productService;

        public CreateProductModel()
        {
            _productService = Startup.AutofacContainer.Resolve<IProductService>();
        }

        public CreateProductModel(IProductService productService)
        {
            _productService = productService;
        }
        internal void CreateProduct()
        {
            var product = new Product()
            {
                Name = Name,
                Price = Price
            };

            _productService.CreateProduct(product);
        }
    }
}
