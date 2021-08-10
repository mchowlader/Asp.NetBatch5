using AutoMapper;
using EO = SocialMedia.Account.Entities;
using BO = SocialMedia.Account.BusinessObjects;

namespace SocialMedia.Account.Profiles
{
    public class AccountProfile : Profile
    {
        public AccountProfile()
        {
            CreateMap<EO.User, BO.User>().ReverseMap();
            CreateMap<EO.Photo, BO.Photo>().ReverseMap();
        }
    }
}
