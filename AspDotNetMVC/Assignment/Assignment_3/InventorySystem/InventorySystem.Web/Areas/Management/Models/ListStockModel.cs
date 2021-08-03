using Autofac;
using InventorySystem.Tracking.Services;
using InventorySystem.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InventorySystem.Web.Areas.Management.Models
{
    public class ListStockModel
    {
        public decimal Quantity { get; set; }

        private readonly IStockService _stockService;

        public ListStockModel()
        {
            _stockService = Startup.AutofacContainer.Resolve<IStockService>();
        }
        public ListStockModel(IStockService stockService)
        {
            _stockService = stockService;
        }

        internal object GetStocks(DataTablesAjaxRequestModel dataTableModel)
        {
            var data = _stockService.GetStocks(
                dataTableModel.PageIndex,
                dataTableModel.PageSize,
                dataTableModel.SearchText,
                dataTableModel.GetSortText(new string[] { "ProductId", "Quantity" }));

            return new
            {
                recordsTotal = data.total,
                recordsFiltered = data.totalDisplay,

                data = (from record in data.records
                        select new string[]
                        {
                            record.ProductId.ToString(),
                            record.Quantity.ToString(),
                            record.Id.ToString()
                        }).ToArray()
            };

        }

        internal void Delete(int id)
        {
            _stockService.DeleteStock(id);
        }
    }
}
