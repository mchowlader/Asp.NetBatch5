using InventorySystem.Tracking.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Autofac;
using System.ComponentModel.DataAnnotations;
using InventorySystem.Tracking.BusinessObjects;

namespace InventorySystem.Web.Areas.Management.Models
{
    public class CreateProductModel
    {
        [Required, MaxLength(50, ErrorMessage ="less than 50")]
        public string Name { get; set; }
        [Required, Range(100,100000)]
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
