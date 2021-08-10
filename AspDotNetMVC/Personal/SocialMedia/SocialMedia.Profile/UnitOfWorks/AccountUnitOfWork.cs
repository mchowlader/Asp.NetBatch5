using Microsoft.EntityFrameworkCore;
using SocialMedia.Account.Contexts;
using SocialMedia.Account.Repositories;
using SocialMedia.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMedia.Account.UnitOfWorks
{
    public class AccountUnitOfWork : UnitOfWork, IAccountUnitOfWork
    {
        public IPhotoRepository Photos { get; private set; }
        public IUserRepository Users { get; private set; }
        public AccountUnitOfWork(IAccountDbContext dbContext,
            IPhotoRepository photoRepository,
            IUserRepository userRepository)
            : base((DbContext)dbContext)
        {
            Photos = photoRepository;
            Users = userRepository;
        }

       
    }
}
