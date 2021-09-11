using AutoMapper;
using DataImporter.Transfer.BusinessObjects;
using DataImporter.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataImporter.Web.Profiles
{
    public class WebProfile : Profile
    {
        public WebProfile()
        {
            CreateMap<Group, CreateGroupModel>().ReverseMap();
        }
    }
}
