using SocialNetwork.Account.BusinessObjects;
using SocialNetwork.Account.UnitOfWorks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.Account.Services
{
    public class MemberService : IMemberService
    {
        private readonly IAccountUnitOfWork _accountUnitOfWork;

        public MemberService(IAccountUnitOfWork accountUnitOfWork)
        {
            _accountUnitOfWork = accountUnitOfWork;
        }
        public void CreateMember(Member member)
        {
            if (member == null)
                throw new InvalidOperationException("member is missing");
            if (member.Name == null)
                throw new InvalidOperationException("Name is missing");
            if (member.DateOfBirth.ToString() == null)
                throw new InvalidOperationException("DateOfBirth is missing");
            if (member.Address == null)
                throw new InvalidOperationException("Address is missing");
            _accountUnitOfWork.Members.Add(
                new Entities.Member()
                {
                    Name = member.Name,
                    DateOfBirth = member.DateOfBirth,
                    Address = member.Address
                });

            _accountUnitOfWork.Save();
        }

      

        public (IList<Member> records, int total, int totalDisplay) GetMembers(int pageIndex, int pageSize, 
            string searchText, string sortText)
        {
            var memberData = _accountUnitOfWork.Members.GetDynamic(
                string.IsNullOrWhiteSpace(searchText)? null: x => x.Name.Contains(searchText),
                sortText, string.Empty, pageIndex, pageSize);

            var resultData = (from member in memberData.data
                             select new Member()
                             { 
                                Name = member.Name,
                                Address = member.Address,
                                DateOfBirth = member.DateOfBirth,
                                Id = member.Id
                             }).ToList();

            return (resultData, memberData.total, memberData.totalDisplay);

        }

        public Member GetMembers(int id)
        {
            var member = _accountUnitOfWork.Members.GetById(id);

            if (member == null) return null;

            return new Member()
            {
                Id = member.Id,
                Name = member.Name,
                Address = member.Address,
                DateOfBirth = member.DateOfBirth
            };
        }

        public void UpdateMember(Member member)
        {
            if (member == null)
                throw new InvalidOperationException();

            var memberEntity = _accountUnitOfWork.Members.GetById(member.Id);

            if(memberEntity != null)
            {
                memberEntity.Name = member.Name;
                memberEntity.Address = member.Address;
                memberEntity.DateOfBirth = member.DateOfBirth;

                _accountUnitOfWork.Save();
            }
        }

        public void DeleteMember(int id)
        {
            _accountUnitOfWork.Members.Remove(id);
            _accountUnitOfWork.Save();
        }
    }
}
