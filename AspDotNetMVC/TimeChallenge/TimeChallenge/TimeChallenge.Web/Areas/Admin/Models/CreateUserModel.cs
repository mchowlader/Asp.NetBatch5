using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TimeChallenge.User.Services;
using Autofac;
using AutoMapper;
using System.ComponentModel.DataAnnotations;
using BO = TimeChallenge.User.BusinessObjects;

namespace TimeChallenge.Web.Areas.Admin.Models
{
    public class CreateUserModel
    {
        [Required, MaxLength(20,ErrorMessage = "must be 20")]
        public string Name { get; set; }
        [Required, MaxLength(40, ErrorMessage = "must be 20")]
        public string Address { get; set; }
        [Required, Range(typeof(DateTime), "01/01/1950", "01/01/2021")]
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
            var user = new BO.User();
            _mapper.Map(this, user);

            //var user = _mapper.Map<BO.User>(this);
            //var user = new BO.User()
            //{
            //    Name = Name,
            //    Address = Address,
            //    DateOfBirth = DateOfBirth
            //};

            _userService.CreateUser(user);
        }
    }
}
