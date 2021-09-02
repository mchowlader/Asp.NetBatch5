using Autofac;
using AutoMapper;
using StockData.Trend.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StockData.Web.Models
{
    public class ListStockPriceModel
    {
        private readonly IMapper _mapper;
        private readonly IStockPriceService _stockPriceService;

        public ListStockPriceModel()
        {
            _stockPriceService = Startup.AutofacContainer.Resolve<IStockPriceService>();
            _mapper = Startup.AutofacContainer.Resolve<IMapper>();
        }

        public ListStockPriceModel(IMapper mapper, IStockPriceService stockPriceService)
        {
            _mapper = mapper;
            _stockPriceService = stockPriceService;
        }

        internal object GetStockPrice(DataTablesAjaxRequestModel dataTablesModel)
        {
            var data = _stockPriceService.GetStockPriceData(
                  dataTablesModel.PageIndex,
                  dataTablesModel.PageSize,
                  dataTablesModel.SearchText,
                  dataTablesModel.GetSortText(new string[] { "CompanyId", "LastTradingPrice", "High", "Low", "ClosePrice",
                  "YesterdayClosePrice", "Change", "Trade", "Value", "Volume"}));

            return new
            {
                recordsTotal = data.total,
                recordsFiltered = data.totalDisplay,
                data = (from record in data.records
                        select new string[]
                        {
                           record.CompanyId.ToString(),
                           record.LastTradingPrice.ToString(),
                           record.High.ToString(),
                           record.Low.ToString(),
                           record.ClosePrice.ToString(),
                           record.YesterdayClosePrice.ToString(),
                           record.Change.ToString(),
                           record.Trade.ToString(),
                           record.Value.ToString(),
                           //record.Volume.ToString(),
                           record.Id.ToString()
                        }).ToArray()
            };
        }
    }
}
