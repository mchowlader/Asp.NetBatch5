using SocialNetwork.Account.Repositories;
using SocialNetwork.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.Account.UnitOfWorks
{
    public interface IAccountUnitOfWork : IUnitOfWork
    {
        IMemberRepository Members { get; }
        IPhotoRepository Photos { get; }
    }
}
