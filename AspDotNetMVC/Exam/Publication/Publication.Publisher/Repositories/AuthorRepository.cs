using Microsoft.EntityFrameworkCore;
using Publication.Data;
using Publication.Publisher.Contexts;
using Publication.Publisher.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Publication.Publisher.Repositories
{
    public class AuthorRepository : Repository<Author, int>, IAuthorRepository
    {
        public AuthorRepository(IPublisherDbContext publisherDbContext)
            : base((DbContext)publisherDbContext)
        {

        }
    }
}
