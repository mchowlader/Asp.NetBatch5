using ECommerceSystem.Item.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Autofac;
using ECommerceSystem.Item.BusinessObjects;

namespace ECommerceSystem.Web.Areas.Admin.Models
{
    public class EditProductModel
    {
        [Required, Range(1, 50000)]
        public int? Id { get; set; }

        [Required, MaxLength(200, ErrorMessage = "Name less than should be 100")]
        public string Name { get; set; }

        [Required, Range(1, 1000000)]
        public int? Price { get; set; }

        private readonly IProductService _productService;

        public EditProductModel()
        {
            _productService = Startup.AutofacContainer.Resolve<IProductService>();
        }
        public EditProductModel(IProductService productService)
        {
            _productService = productService;
        }

        internal void LoadModelData(int id)
        {
            var product = _productService.GetProducts(id);
            Id = product?.Id;
            Name = product?.Name;
            Price = product?.Price;
        }

        internal void Update()
        {
            var product = new Product()
            {
                Id = Id.HasValue? Id.Value : 0,
                Name = Name,
                Price = Price.HasValue? Price.Value : 0
            };

            _productService.UpdateProduct(product);
        }
    }
}
