using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimeChallenge.Data;
using TimeChallenge.User.Contexts;
using TimeChallenge.User.Repositories;

namespace TimeChallenge.User.UnitOfWorks
{
    public class UserUnitOfWork : UnitOfWork, IUserUnitOfWork 
    {
        public IUserRepository Users { get; private set; }

        public UserUnitOfWork(IUserDbContext userDbContext, IUserRepository userRepository)
            :base((DbContext)userDbContext)
        {
            Users = userRepository;
        }

    }
}
