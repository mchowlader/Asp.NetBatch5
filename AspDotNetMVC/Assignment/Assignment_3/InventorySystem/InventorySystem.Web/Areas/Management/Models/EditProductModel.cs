using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Autofac;
using InventorySystem.Tracking.BusinessObjects;
using InventorySystem.Tracking.Services;

namespace InventorySystem.Web.Areas.Management.Models
{
    public class EditProductModel
    {
        [Required]
        public int?  Id { get; set; }
        [Required, MaxLength(50, ErrorMessage = "less than 50")]
        public string? Name { get; set; }
        [Required, Range(100, 100000)]
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
            var productData = _productService.GetProduct(id);

            Id = productData?.Id;
            Name = productData?.Name;
            Price = productData?.Price;
        }

        internal void Update()
        {
            var product = new Product()
            {
                Id = Id.HasValue? Id.Value : 0,
                Name = Name,
                Price = Price.HasValue? Price.Value : 0,
            };

            _productService.UpdateProduct(product);
        }
    }
}
