using AutoMapper;
using StockData.Trend.BusinessObject;
using StockData.Trend.UnitIfWorks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockData.Trend.Services
{
    public class StockPriceService : IStockPriceService
    {
        private readonly ITrendUnitOfWork _trendUnitOfWork;

        public StockPriceService( ITrendUnitOfWork trendUnitOfWork)
        {
            _trendUnitOfWork = trendUnitOfWork;
        }

    }
}
