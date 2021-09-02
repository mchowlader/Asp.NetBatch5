using StockData.Trend.BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockData.Trend.Services
{
    public interface IStockPriceService
    {
        void SetStockData(StockPrice stockPrice);
    }
}
