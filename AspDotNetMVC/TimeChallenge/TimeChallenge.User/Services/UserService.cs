using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimeChallenge.User.UnitOfWorks;
using BO = TimeChallenge.User.BusinessObjects;
using EO = TimeChallenge.User.Entities;

namespace TimeChallenge.User.Services
{
    public class UserService : IUserService
    {
        private readonly IUserUnitOfWork _userUnitOfWork;
        private readonly IMapper _mapper;
        public UserService(IUserUnitOfWork userUnitOfWork, IMapper mapper)
        {
            _mapper = mapper;
            _userUnitOfWork = userUnitOfWork;
        }

        public void CreateUser(BO.User user)
        {

            _userUnitOfWork.Users.Add(
                _mapper.Map<EO.User>(user));
            _userUnitOfWork.Save();
        }

        public void DeleteUser(int id)
        {
            _userUnitOfWork.Users.Remove(id);
            _userUnitOfWork.Save();
        }

        public (IList<BO.User> records, int total, int totalDisplay) GetUsers(int pageIndex, 
            int pageSize, string searchText, string sortText)
        {
            var resultEntities = _userUnitOfWork.Users.GetDynamic(string.IsNullOrWhiteSpace(
                searchText)? null: x => x.Name.Contains(searchText),
                sortText, string.Empty, pageIndex, pageSize);
            var resultsData = (from data in resultEntities.data
                              select _mapper.Map<BO.User>(data)).ToList();

            return (resultsData, resultEntities.total, resultEntities.totalDisplay);
        }

        public BO.User GetUsers(int id)
        {
            var userEntity = _userUnitOfWork.Users.GetById(id);
            return _mapper.Map<BO.User>(userEntity);
        }

        public void UpdateUser(BO.User user)
        {
            if (user == null)
                throw new InvalidOperationException("missing user");
            var userEntity = _userUnitOfWork.Users.GetById(user.Id);

            if(userEntity != null)
            {
                _mapper.Map(user, userEntity);
                _userUnitOfWork.Save();
            }
        }
    }
}
