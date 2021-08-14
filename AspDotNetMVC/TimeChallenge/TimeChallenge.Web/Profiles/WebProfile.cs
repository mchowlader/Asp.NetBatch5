using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TimeChallenge.Web.Areas.Admin.Models;
using BO = TimeChallenge.User.BusinessObjects;

namespace TimeChallenge.Web.Profiles
{
    public class WebProfile : Profile
    {
        public WebProfile()
        {
            CreateMap<CreateUserModel, BO.User>().ReverseMap();
            CreateMap<EditUserModel, BO.User>().ReverseMap();
        }
    }
}
