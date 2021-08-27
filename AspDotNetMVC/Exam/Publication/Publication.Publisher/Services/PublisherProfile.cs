using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BO = Publication.Publisher.BusinessObjects;
using EO = Publication.Publisher.Entities;

namespace Publication.Publisher.Services
{
    public class PublisherProfile : Profile
    {
        public PublisherProfile()
        {
            CreateMap<BO.Author, EO.Author>().ReverseMap();
            CreateMap<BO.Book, EO.Book>().ReverseMap();
        }
    }
}
