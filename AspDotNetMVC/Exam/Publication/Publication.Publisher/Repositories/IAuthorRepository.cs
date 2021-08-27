using Publication.Data;
using Publication.Publisher.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Publication.Publisher.Repositories
{
    public interface IAuthorRepository : IRepository<Author,int>
    {
    }
}
