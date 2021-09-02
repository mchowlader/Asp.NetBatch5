using AutoMapper;
using StockData.Trend.BusinessObject;
using StockData.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StockData.Web.Profiles
{
    public class WebProfile : Profile
    {
        public WebProfile()
        {
            CreateMap<CreateCompanyModel, Company>().ReverseMap();
            CreateMap<ListCompanyModel, Company>().ReverseMap();
            CreateMap<EditCompanyModel, Company>().ReverseMap();

            CreateMap<CreateStockPriceModel, StockPrice>().ReverseMap();
            CreateMap<ListStockPriceModel, StockPrice>().ReverseMap();
        }
    }
}
