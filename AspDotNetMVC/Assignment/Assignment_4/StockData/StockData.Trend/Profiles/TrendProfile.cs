using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EO = StockData.Trend.Entities;
using BO = StockData.Trend.BusinessObject;

namespace StockData.Trend.Profiles
{
    public class TrendProfile : Profile
    {
        public TrendProfile()
        {
            CreateMap<BO.Company, EO.Company>().ReverseMap();
            CreateMap<BO.StockPrice, EO.StockPrice>().ReverseMap();
        }
    }
}
