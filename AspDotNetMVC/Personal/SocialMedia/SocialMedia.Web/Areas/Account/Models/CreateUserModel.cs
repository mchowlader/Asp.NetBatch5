using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Autofac;
using AutoMapper;
using SocialMedia.Account.BusinessObjects;
using SocialMedia.Account.Services;

namespace SocialMedia.Web.Areas.Account.Models
{
    public class CreateUserModel
    {
        [Required, MaxLength(30, ErrorMessage = "Title should be less than 200 charcaters")]
        public string Name { get; set; }
        [Required, MaxLength(50, ErrorMessage = "Title should be less than 200 charcaters")]
        public string Address { get; set; }
        [Required, Range(typeof(DateTime),"01/01/1950", "01/01/2020")]
        public DateTime DateOfBirth { get; set; }

        private readonly IUserService _userService;
        private readonly IMapper _mapper;
        public CreateUserModel()
        {
            _mapper = Startup.AutofacContainer.Resolve<IMapper>();
            _userService = Startup.AutofacContainer.Resolve<IUserService>();
            
        }
        public CreateUserModel(IUserService userService, IMapper mapper)
        {
            _mapper = mapper;
            _userService = userService;
        }
        internal void CreateUser()
        {
            var user = _mapper.Map<User>(this);

            _userService.CreateUser(user);
        }
    }
}
