using Microsoft.EntityFrameworkCore;
using SocialNetwork.Account.Contexts;
using SocialNetwork.Account.Repositories;
using SocialNetwork.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.Account.UnitOfWorks
{
    public class AccountUnitOfWork : UnitOfWork, IAccountUnitOfWork
    {
        public IMemberRepository Members { get; private set; }
        public IPhotoRepository Photos { get; private set; }

        public AccountUnitOfWork(IAccountDbContext dbContext,
            IMemberRepository memberRepository,
            IPhotoRepository photoRepository)
           : base((DbContext)dbContext)
        {
            Members = memberRepository;
            Photos = photoRepository;
        }

    }
}
