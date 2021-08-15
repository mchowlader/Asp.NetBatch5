using AutoMapper;
using SchoolManagement.Web.Areas.Admin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BO = SchoolManagement.Present.BusinessObjects;

namespace SchoolManagement.Web.Profiles
{
    public class WebProfile : Profile
    {
        public WebProfile()
        {
            CreateMap<CreateStudentModel, BO.Student>().ReverseMap();
        }
    }
}
