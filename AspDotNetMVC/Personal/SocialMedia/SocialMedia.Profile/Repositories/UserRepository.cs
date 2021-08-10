using Microsoft.EntityFrameworkCore;
using SocialMedia.Account.Contexts;
using SocialMedia.Account.Entities;
using SocialMedia.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMedia.Account.Repositories
{
    public class UserRepository : Repository<User, int>, IUserRepository
    {
        public UserRepository(IAccountDbContext dbContext)
           : base((DbContext)dbContext)
        {

        }
    }
}
