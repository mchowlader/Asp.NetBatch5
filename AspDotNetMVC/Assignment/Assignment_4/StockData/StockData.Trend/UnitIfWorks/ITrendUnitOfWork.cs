using StockData.Trend.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockData.Trend.UnitIfWorks
{
    public interface ITrendUnitOfWork
    {
        ICompanyRepository Companys { get; }
        IStockPriceRepository StockPrices { get; }
    }
}
