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
    public class PhotoRepository : Repository<Photo, int>, IPhotoRepository
    {
        public PhotoRepository(IAccountDbContext dbContext)
          : base((DbContext)dbContext)
        {

        }
    }
}
