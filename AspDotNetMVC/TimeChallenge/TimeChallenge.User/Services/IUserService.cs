using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BO = TimeChallenge.User.BusinessObjects;

namespace TimeChallenge.User.Services
{
    public interface IUserService
    {
        void CreateUser(BusinessObjects.User user);
        (IList<BO.User> records, int total, int totalDisplay) GetUsers(int pageIndex, int pageSize, 
            string searchText, string sortText);
        BO.User GetUsers(int id);
        void UpdateUser(BO.User user);
        void DeleteUser(int id);
    }
}
