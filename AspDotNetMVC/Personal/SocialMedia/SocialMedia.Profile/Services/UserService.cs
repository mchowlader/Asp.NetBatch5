using AutoMapper;
using SocialMedia.Account.BusinessObjects;
using SocialMedia.Account.UnitOfWorks;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SocialMedia.Account.Services
{
    public class UserService : IUserService
    {
        private readonly IAccountUnitOfWork _accountUnitOfWork;
        private readonly IMapper _mapper;
        public UserService(IAccountUnitOfWork accountUnitOfWork, IMapper mapper)
        {
            _mapper = mapper;
            _accountUnitOfWork = accountUnitOfWork;

        }
        public void CreateUser(User user)
        {
            _accountUnitOfWork.Users.Add(
                _mapper.Map<Entities.User>(user));
               
            _accountUnitOfWork.Save();
        }

        public void DeleteUser(int id)
        {
            _accountUnitOfWork.Users.Remove(id);
            _accountUnitOfWork.Save();
        }

        public (IList<User> records, int total, int totalDisplay) GetUsers(int pageIndex, 
            int pageSize, string searchText, string sortText)
        {
            var userData = _accountUnitOfWork.Users.GetDynamic(
                string.IsNullOrWhiteSpace(searchText)? null: x => x.Name.Contains(searchText),
                sortText, string.Empty, pageIndex, pageSize);

            var resultData = (from user in userData.data
                             select _mapper.Map<User>(user)).ToList();

            return (resultData, userData.total, userData.totalDisplay);
        }

        public User GetUsers(int id)
        {
            var user = _accountUnitOfWork.Users.GetById(id);
            return _mapper.Map<User>(user);
        }

        public void UpdateUser(User user)
        {
            if (user == null)
                throw new InvalidOperationException();
            var userEntity = _accountUnitOfWork.Users.GetById(user.Id);

            if(userEntity != null)
            {
                _mapper.Map(user, userEntity);
                _accountUnitOfWork.Save();
            }
        }

    }
}
