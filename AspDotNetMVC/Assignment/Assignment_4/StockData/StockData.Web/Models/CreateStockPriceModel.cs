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
    public class CreateStockPriceModel
    {
        public int CompanyId { get; set; }
        public double LastTradingPrice { get; set; }
        public double High { get; set; }
        public double Low { get; set; }
        public double ClosePrice { get; set; }
        public double YesterdayClosePrice { get; set; }
        public double Change { get; set; }
        public int Trade { get; set; }
        public double Value { get; set; }
        public double Volume { get; set; }

        private readonly IMapper _mapper;
        private readonly IStockPriceService _stockPriceService;

        public CreateStockPriceModel()
        {
            _stockPriceService = Startup.AutofacContainer.Resolve<IStockPriceService>();
            _mapper = Startup.AutofacContainer.Resolve<IMapper>();
        }

        public CreateStockPriceModel(IMapper mapper, IStockPriceService  stockPriceService)
        {
            _mapper = mapper;
            _stockPriceService = stockPriceService;
        }

        internal void CreateStockPric()
        {
            var stockPrice = _mapper.Map<StockPrice>(this);

            _stockPriceService.CreateStockPric(stockPrice);
        }
    }
}
