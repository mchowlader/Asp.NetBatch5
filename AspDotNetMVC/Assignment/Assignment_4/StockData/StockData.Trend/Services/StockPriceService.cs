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
        public int CompanyId { get; set; }
        public StockPriceService( ITrendUnitOfWork trendUnitOfWork)
        {
            _trendUnitOfWork = trendUnitOfWork;
        }

        public void SetStockData(StockPrice stockPricee)
        {
            if (isValidCompany(stockPricee.TradeCode))
            {
                var companyEntity = _trendUnitOfWork.Companys.GetAll();

                foreach (var company in companyEntity)
                {
                    if(stockPricee.TradeCode == company.TradeCode)
                    {
                        CompanyId = company.Id;
                        break;
                    }
                }
            }

            else
            {
                _trendUnitOfWork.Companys.Add(
               new Entities.Company()
               {
                   TradeCode = stockPricee.TradeCode
               });
                _trendUnitOfWork.Save();

                var companyEntity = _trendUnitOfWork.Companys.GetAll();

                foreach (var company in companyEntity)
                {
                    if (stockPricee.TradeCode == company.TradeCode)
                    {
                        CompanyId = company.Id;
                        break;
                    }
                }
            }

            _trendUnitOfWork.StockPrices.Add(
               new Entities.StockPrice
               {
                   CompanyId = CompanyId,
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

        private bool isValidCompany(string name) =>
            _trendUnitOfWork.Companys.GetCount(x => x.TradeCode == name) > 0;
    }
}
