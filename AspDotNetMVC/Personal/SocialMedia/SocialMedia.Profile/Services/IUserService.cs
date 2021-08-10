using SocialMedia.Account.BusinessObjects;
using System.Collections.Generic;

namespace SocialMedia.Account.Services
{
    public interface IUserService
    {
        void CreateUser(User user);
        (IList<User> records, int total, int totalDisplay) GetUsers(int pageIndex, int pageSize, 
            string searchText, string sortText);
        User GetUsers(int id);
        void UpdateUser(User user);
        void DeleteUser(int id);
    }
}
