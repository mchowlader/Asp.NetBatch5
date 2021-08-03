using ECommerceSystem.Item.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Autofac;
using ECommerceSystem.Item.BusinessObjects;
using ECommerceSystem.Web.Models;

namespace ECommerceSystem.Web.Areas.Admin.Models
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

        internal object GetProducts(DataTablesAjaxRequestModel dataTablesModel)
        {
            var data = _productService.GetProducts(
                dataTablesModel.PageIndex,
                dataTablesModel.PageSize,
                dataTablesModel.SearchText,
                dataTablesModel.GetSortText(new string[] {"Name", "Price" }));

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
