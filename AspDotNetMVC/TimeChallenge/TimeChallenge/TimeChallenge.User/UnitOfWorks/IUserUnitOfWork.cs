using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimeChallenge.Data;
using TimeChallenge.User.Repositories;

namespace TimeChallenge.User.UnitOfWorks
{
    public interface IUserUnitOfWork : IUnitOfWork
    {
        public IUserRepository Users { get; }
    }
}
