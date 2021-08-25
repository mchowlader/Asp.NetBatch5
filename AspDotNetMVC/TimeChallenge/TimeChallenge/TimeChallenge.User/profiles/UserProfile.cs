using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EO = TimeChallenge.User.Entities;
using BO = TimeChallenge.User.BusinessObjects;

namespace TimeChallenge.User.profiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<EO.Photo, BO.Photo>().ReverseMap();
            CreateMap<EO.User, BO.User>().ReverseMap();
        }
    }
}
