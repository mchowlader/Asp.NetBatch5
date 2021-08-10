using SocialMedia.Account.Repositories;
using SocialMedia.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMedia.Account.UnitOfWorks
{
    public interface IAccountUnitOfWork : IUnitOfWork
    {
        IPhotoRepository Photos { get; }
        IUserRepository Users { get; }
    }
}
