using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EO = SchoolManagement.Present.Entities;
using BO = SchoolManagement.Present.BusinessObjects;

namespace SchoolManagement.Present.Profiles
{
    public class PresentProfile : Profile
    {
        public PresentProfile()
        {
            CreateMap<EO.Student, BO.Student>().ReverseMap();
            CreateMap<EO.Course, BO.Course>().ReverseMap();
            CreateMap<EO.Topic, BO.Topic>().ReverseMap();
        }
    }
}
