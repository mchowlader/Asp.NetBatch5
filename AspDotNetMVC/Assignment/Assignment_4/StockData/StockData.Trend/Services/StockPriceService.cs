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

        public void SetStockData(StockPrice stockPricee)
        {
            _trendUnitOfWork.StockPrices.Add(
               new Entities.StockPrice
               {
                   CompanyId = 4,
                   Trade = stockPricee.Trade,
                   LastTradingPrice = stockPricee.LastTradingPrice,
                   Change = stockPricee.Change,
                   ClosePrice = stockPricee.ClosePrice,
                   High = stockPricee.High,
                   Low = stockPricee.Low,
                   Value = stockPricee.Value,
                   Volume = stockPricee.Volume,
                   YesterdayClosePrice = stockPricee.YesterdayClosePrice
               });

            _trendUnitOfWork.Save();
        }
    }
}
