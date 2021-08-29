using Microsoft.EntityFrameworkCore;
using StockData.Data;
using StockData.Trend.Contexts;
using StockData.Trend.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockData.Trend.Repositories
{
    public class CompanyRepository : Repository<Company, int>, ICompanyRepository
    {
        public CompanyRepository(ITrendDbContext trendDbContext)
            : base((DbContext)trendDbContext)
        {

        }
    }
}
