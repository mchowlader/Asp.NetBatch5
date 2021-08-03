﻿using Microsoft.EntityFrameworkCore;
using SocialNetwork.Account.Contexts;
using SocialNetwork.Account.Entities;
using SocialNetwork.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.Account.Repositories
{
    public class MemberRepository : Repository<Member, int>, IMemberRepository
    {
        public MemberRepository(IAccountDbContext dbContext)
           : base((DbContext)dbContext)
        {

        }
    }
}
