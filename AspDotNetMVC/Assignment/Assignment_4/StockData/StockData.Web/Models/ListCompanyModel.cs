using Autofac;
using AutoMapper;
using StockData.Trend.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StockData.Web.Models
{
    public class ListCompanyModel
    {
        private readonly IMapper _mapper;
        private readonly ICompanyService _companyServices;

        public ListCompanyModel()
        {
            _companyServices = Startup.AutofacContainer.Resolve<ICompanyService>();
            _mapper = Startup.AutofacContainer.Resolve<IMapper>();
        }

        public ListCompanyModel(IMapper mapper, ICompanyService companyService)
        {
            _mapper = mapper;
            _companyServices = companyService;
        }

        internal object GetCompany(DataTablesAjaxRequestModel dataTablesModel)
        {
            var data = _companyServices.GetCompanyData(
                 dataTablesModel.PageIndex,
                 dataTablesModel.PageSize,
                 dataTablesModel.SearchText,
                 dataTablesModel.GetSortText(new string[] { "TradeCode" }));

            return new
            {
                recordsTotal = data.total,
                recordsFiltered = data.totalDisplay,
                data = (from record in data.records
                        select new string[]
                        {
                           record.TradeCode,
                           record.Id.ToString()
                        }).ToArray()
            };
        }

        internal void Delete(int id)
        {
            _companyServices.DeleteCompany(id);
        }
    }
}
