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
    public class BookRepository : Repository<Book, int>, IBookRepository
    {
        public BookRepository(IPublisherDbContext publisherDbContext)
           : base((DbContext)publisherDbContext)
        {

        }

    }
}
