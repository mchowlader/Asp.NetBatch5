using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimeChallenge.Data;
using TimeChallenge.User.Contexts;
using EO = TimeChallenge.User.Entities;

namespace TimeChallenge.User.Repositories
{
    public class UserRepository : Repository<EO.User, int>, IUserRepository
    {
        public UserRepository(IUserDbContext userDbContext)
           : base((DbContext)userDbContext)
        {

        }
    }
}
