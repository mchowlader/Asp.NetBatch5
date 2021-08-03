using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Autofac;
using SocialNetwork.Account.BusinessObjects;
using SocialNetwork.Account.Services;

namespace SocialNetwork.Web.Areas.Netizen.Models
{
    public class EditMemberModel
    {
        [Required]
        public int? Id { get; set; }
        [Required, MaxLength(50, ErrorMessage = "Must be less than 50")]
        public string Name { get; set; }
        [Required, Range(typeof(DateTime), "01/01/1950", "01/01/2021")]
        public DateTime? DateOfBirth { get; set; }
        [Required, MaxLength(100, ErrorMessage = "Must be less than 50")]
        public string Address { get; set; }

        private readonly IMemberService _memberService;

        public EditMemberModel()
        {
            _memberService = Startup.AutofacContainer.Resolve<IMemberService>();
        }
        public EditMemberModel(IMemberService memberService)
        {
            _memberService = memberService;
        }

        internal void LoadModelData(int id)
        {
            var member = _memberService.GetMembers(id);

            Id = member?.Id;
            Name = member.Name;
            Address = member.Address;
            DateOfBirth = member?.DateOfBirth;
        }

        internal void Update()
        {
            var member = new Member()
            {
                Id = Id.HasValue ? Id.Value : 0,
                Name = Name,
                Address = Address,
                DateOfBirth = DateOfBirth.HasValue ? DateOfBirth.Value : DateTime.MinValue
            };

            _memberService.UpdateMember(member);
        }
    }
}
