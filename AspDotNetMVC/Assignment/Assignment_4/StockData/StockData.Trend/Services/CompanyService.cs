using AutoMapper;
using StockData.Trend.UnitIfWorks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockData.Trend.Services
{
    public class CompanyService : ICompanyService
    {
        private readonly ITrendUnitOfWork _trendUnitOfWork;
        private readonly IMapper _mapper;

        public CompanyService(IMapper mapper,ITrendUnitOfWork trendUnitOfWork)
        {
            _mapper = mapper;
            _trendUnitOfWork = trendUnitOfWork;
        }
    }
}
