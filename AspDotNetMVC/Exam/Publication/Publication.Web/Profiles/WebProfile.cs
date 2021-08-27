using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Publication.Web.Areas.Admin.Models;
using Publication.Publisher.BusinessObjects;

namespace Publication.Web.Profiles
{
    public class WebProfile : Profile
    {
        public WebProfile()
        {
            CreateMap<CreateBookModel, Book>().ReverseMap();
            CreateMap<EditBookModel, Book>().ReverseMap();
            CreateMap<ListBookModel, Book>().ReverseMap();
        }
    }
}
