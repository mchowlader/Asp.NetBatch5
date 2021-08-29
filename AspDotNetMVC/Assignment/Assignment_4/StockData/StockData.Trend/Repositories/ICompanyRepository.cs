using StockData.Data;
using StockData.Trend.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockData.Trend.Repositories
{
    public interface ICompanyRepository : IRepository<Company, int>
    {

    }
}
