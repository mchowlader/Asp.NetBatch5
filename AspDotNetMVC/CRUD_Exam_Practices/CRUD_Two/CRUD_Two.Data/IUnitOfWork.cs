using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUD_Two.Data
{
    public interface IUnitOfWork : IDisposable
    {
        void Save();
    }
}
