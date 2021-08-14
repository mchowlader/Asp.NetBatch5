using Autofac;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using TimeChallenge.User.Services;
using BO = TimeChallenge.User.BusinessObjects;

namespace TimeChallenge.Web.Areas.Admin.Models
{
    public class EditUserModel
    {
        [Required]
        public int Id { get; set; }
        [Required, MaxLength(20, ErrorMessage = "must be 20")]
        public string Name { get; set; }
        [Required, MaxLength(40, ErrorMessage = "must be 20")]
        public string Address { get; set; }
        [Required, Range(typeof(DateTime), "01/01/1950", "01/01/2021")]
        public DateTime DateOfBirth { get; set; }

        private readonly IUserService _userService;
        private readonly IMapper _mapper;
        public EditUserModel()
        {
            _mapper = Startup.AutofacContainer.Resolve<IMapper>();
            _userService = Startup.AutofacContainer.Resolve<IUserService>();
        }

        public EditUserModel(IUserService userService, IMapper mapper)
        {
            _mapper = mapper;
            _userService = userService;
        }

        internal void LoadModelData(int id)
        {
            var user = _userService.GetUsers(id);
            _mapper.Map(user, this);
        }

        internal void Update()
        {
            var user = _mapper.Map<BO.User>(this);
            _userService.UpdateUser(user);
        }
    }
}
