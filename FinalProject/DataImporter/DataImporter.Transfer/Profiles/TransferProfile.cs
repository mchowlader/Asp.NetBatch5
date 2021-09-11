﻿using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EO = DataImporter.Transfer.Entities;
using BO = DataImporter.Transfer.BusinessObjects;

namespace DataImporter.Transfer.Profiles
{
    public class TransferProfile : Profile
    {
        public TransferProfile()
        {
            CreateMap<BO.Group, EO.Group>().ReverseMap();
        }
    }
}
