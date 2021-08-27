using Microsoft.EntityFrameworkCore;
using Publication.Data;
using Publication.Publisher.Contexts;
using Publication.Publisher.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Publication.Publisher.UnitOfWorks
{
    public class PublisherUnitOfWork : UnitOfWork, IPublisherUnitOfWork
    {
        public IAuthorRepository Authors { get; private set; }

        public IBookRepository Books { get; private set; }

        public PublisherUnitOfWork(IPublisherDbContext publisherDbContext,
            IAuthorRepository authorRepository,
            IBookRepository bookRepository)
           : base((DbContext)publisherDbContext)
        {
            Authors = authorRepository;
            Books = bookRepository;
        }
    }
}
