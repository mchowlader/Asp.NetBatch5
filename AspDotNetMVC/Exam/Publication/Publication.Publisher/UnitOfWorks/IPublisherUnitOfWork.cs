using Publication.Data;
using Publication.Publisher.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Publication.Publisher.UnitOfWorks
{
    public interface IPublisherUnitOfWork : IUnitOfWork
    {
        IAuthorRepository Authors { get; }
        IBookRepository Books { get; }
    }
}
