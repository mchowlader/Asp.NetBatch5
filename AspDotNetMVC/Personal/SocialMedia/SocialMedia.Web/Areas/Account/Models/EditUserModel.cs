using Autofac;
using AutoMapper;
using SocialMedia.Account.BusinessObjects;
using SocialMedia.Account.Services;
using System;
using System.ComponentModel.DataAnnotations;

namespace SocialMedia.Web.Areas.Account.Models
{
    public class EditUserModel
    {
        [Required]
        public int Id { get; set; }
        [Required, MaxLength(30, ErrorMessage = "Title should be less than 200 charcaters")]
        public string Name { get; set; }
        [Required, MaxLength(50, ErrorMessage = "Title should be less than 200 charcaters")]
        public string Address { get; set; }
        [Required, Range(typeof(DateTime), "01/01/1950", "01/01/2020")]
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

        internal void LoadModeldata(int id)
        {
            var user = _userService.GetUsers(id);
            _mapper.Map(user, this);

        }

        internal void Update()
        {
            var user = _mapper.Map<User>(this);

            /*var user = _mapper.Map<User>(this);

            Both are working properle.j kono ekta mapping use kora jete pare , 
            hoy, 
            [Map<> ata bebohar korle new object toiri kore nite hobe na]
            [Map() ata bebohar korle new object toiri kore niye then [this] bebohar korte hobe]
            
            var user = new User();
           _mapper.Map(this, user);*/

            _userService.UpdateUser(user);
        }
    }
}
