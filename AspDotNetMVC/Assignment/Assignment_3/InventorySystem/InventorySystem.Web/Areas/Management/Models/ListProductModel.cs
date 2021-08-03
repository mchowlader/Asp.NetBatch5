using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Autofac;
using InventorySystem.Tracking.Services;
using InventorySystem.Web.Models;

namespace InventorySystem.Web.Areas.Management.Models
{
    public class ListProductModel
    {
        private readonly IProductService _productService;

        public ListProductModel()
        {
            _productService = Startup.AutofacContainer.Resolve<IProductService>();
        }
        public ListProductModel(IProductService productService)
        {
            _productService = productService;
        }

        internal object GetProduct(DataTablesAjaxRequestModel dataTableModel)
        {
            var data = _productService.GetProduct(
                dataTableModel.PageIndex,
                dataTableModel.PageSize,
                dataTableModel.SearchText,
                dataTableModel.GetSortText(new string[] {"Name", "Price" }));

            return new
            {
                recordsTotal = data.total,
                recordsFiltered = data.totalDisplay,

                data = (from record in data.records
                       select new string[]
                       {
                           record.Name,
                           record.Price.ToString(),
                           record.Id.ToString()
                       }).ToArray()
            };

        }

        internal void Delete(int id)
        {
            _productService.DeleteProduct(id);
        }
    }
}
