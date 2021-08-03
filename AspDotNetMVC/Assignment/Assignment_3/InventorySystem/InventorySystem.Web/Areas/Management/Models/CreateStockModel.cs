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
    public class CreateStockModel
    {
        [Required]
        public int ProductId { get; set; }
        [Required]
        public decimal Quantity { get; set; }

        private readonly IStockService _stockService;

        public CreateStockModel()
        {
            _stockService = Startup.AutofacContainer.Resolve<IStockService>();
        }
        public CreateStockModel(IStockService stockService)
        {
            _stockService = stockService;
        }

        internal void CreateStock()
        {
            var stock = new Stock()
            {
                ProductId = ProductId,
                Quantity = Quantity
            };

            _stockService.CreateStock(stock);
        }
    }
}
