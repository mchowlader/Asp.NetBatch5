using System;
using System.ComponentModel.DataAnnotations;
using Autofac;
using SocialNetwork.Account.BusinessObjects;
using SocialNetwork.Account.Services;

namespace SocialNetwork.Web.Areas.Netizen.Models
{
    public class CreateMemberModel
    {
        [Required, MaxLength(50, ErrorMessage = "Must be less than 50") ]
        public string Name { get; set; }
        [Required, Range(typeof(DateTime), "01/01/1950", "01/01/2021")]
        public DateTime DateOfBirth { get; set; }
        [Required, MaxLength(100, ErrorMessage = "Must be less than 50")]
        public string Address { get; set; }

        private readonly IMemberService _memberService;

        public CreateMemberModel()
        {
            _memberService = Startup.AutofacContainer.Resolve<IMemberService>();
        }
        public CreateMemberModel(IMemberService memberService)
        {
            _memberService = memberService;
        }

        internal void CreateMember()
        {
            var member = new Member()
            {
                Name = Name,
                DateOfBirth = DateOfBirth,
                Address = Address
            };

            _memberService.CreateMember(member);
        }
    }
}
