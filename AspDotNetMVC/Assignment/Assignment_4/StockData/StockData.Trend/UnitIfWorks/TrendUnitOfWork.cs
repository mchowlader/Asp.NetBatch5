using Microsoft.EntityFrameworkCore;
using StockData.Data;
using StockData.Trend.Contexts;
using StockData.Trend.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockData.Trend.UnitIfWorks
{
    public class TrendUnitOfWork : UnitOfWork, ITrendUnitOfWork
    {
        public ICompanyRepository Companys { get; private set; }
        public IStockPriceRepository StockPrices { get; private set; }

        public TrendUnitOfWork(ITrendDbContext trendDbContext,
            ICompanyRepository companyRepository,
            IStockPriceRepository stockPriceRepository)
            : base((DbContext)trendDbContext)
        {
            Companys = companyRepository;
            StockPrices = stockPriceRepository;
        }


    }
}
