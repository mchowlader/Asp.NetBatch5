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
    public class CreateCompanyModel
    {
        public int Id { get; set; }
        public string TradeCode { get; set; }

        private readonly IMapper _mapper;
        private readonly ICompanyService _companyServices;

        public CreateCompanyModel()
        {
            _companyServices = Startup.AutofacContainer.Resolve<ICompanyService>();
            _mapper = Startup.AutofacContainer.Resolve<IMapper>();
        }

        public CreateCompanyModel(IMapper mapper,ICompanyService companyService)
        {
            _mapper = mapper;
            _companyServices = companyService;
        }

        internal void CreateCompany()
        {
            var company = _mapper.Map<Company>(this);

            _companyServices.CreateCompany(company);
        }
    }
}
