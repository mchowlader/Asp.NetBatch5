using Autofac;
using AutoMapper;
using StockData.Trend.BusinessObject;
using StockData.Trend.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StockData.Web.Models
{
    public class EditCompanyModel
    {
        public int Id { get; set; }
        public string TradeCode { get; set; }

        private readonly IMapper _mapper;
        private readonly ICompanyService _companyServices;

        public EditCompanyModel()
        {
            _companyServices = Startup.AutofacContainer.Resolve<ICompanyService>();
            _mapper = Startup.AutofacContainer.Resolve<IMapper>();
        }

        public EditCompanyModel(IMapper mapper, ICompanyService companyService)
        {
            _mapper = mapper;
            _companyServices = companyService;
        }

        internal void LoadModelData(int id)
        {
            var company = _companyServices.GetCompany(id);
            _mapper.Map(company, this);
        }

        internal void UpdateCompany()
        {
            var company = _mapper.Map<Company>(this);
            _companyServices.UpdateCompany(company);
        }

    }
}
