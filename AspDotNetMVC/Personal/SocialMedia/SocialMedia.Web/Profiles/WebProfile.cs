using SocialMedia.Web.Areas.Account.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using SocialMedia.Account.BusinessObjects;

namespace SocialMedia.Web.Profiles
{
    public class WebProfile : Profile
    {
        public WebProfile()
        {
            CreateMap<CreateUserModel, User>().ReverseMap();
            CreateMap<EditUserModel, User>().ReverseMap();
            
        }
    }
}
