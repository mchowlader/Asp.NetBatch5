using Autofac;
using InventorySystem.Tracking.Services;
using nventorySystem.Tracking.BusinessObjects;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace InventorySystem.Web.Areas.Management.Models
{
    public class EditStockModel
    {
        public int? Id { get; set; }
        [Required]
        public int? ProductId { get; set; }
        [Required]
        public decimal? Quantity { get; set; }

        private readonly IStockService _stockService;

        public EditStockModel()
        {
            _stockService = Startup.AutofacContainer.Resolve<IStockService>();
        }
        public EditStockModel(IStockService stockService)
        {
            _stockService = stockService;
        }
        internal void LoadModelData(int id)
        {
            var stock = _stockService.GetStocks(id);

            Id = stock.Id;
            ProductId = stock.ProductId;
            Quantity = stock.Quantity;
            
        }

        internal void Update()
        {
            var stock = new Stock()
            {
                Id = Id.HasValue?  Id.Value : 0,
                ProductId = ProductId.HasValue? ProductId.Value : 0,
                Quantity = Quantity.HasValue? Quantity.Value : 0,
            };

            _stockService.UpdateStock(stock);
        }
    }
}
