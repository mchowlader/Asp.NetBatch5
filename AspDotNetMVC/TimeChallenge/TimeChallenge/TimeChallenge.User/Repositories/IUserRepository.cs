using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimeChallenge.Data;
using EO = TimeChallenge.User.Entities;

namespace TimeChallenge.User.Repositories
{
    public interface IUserRepository : IRepository<EO.User, int>
    {

    }
}
