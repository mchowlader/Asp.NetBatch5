﻿using AutoMapper;
using DataImporter.Transfer.BusinessObjects;
using DataImporter.Web.Models;
using DataImporter.Web.Models.Groups;
using DataImporter.Web.Models.Imports;
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
            CreateMap<Group, EditGroupModel>().ReverseMap();
            CreateMap<Group, ListGroupModel>().ReverseMap();
            CreateMap<Import, ListImportModel>().ReverseMap();
        }
    }
}
