using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Publication.Data
{
    public interface IUnitOfWork : IDisposable
    {
        void Save();
    }
}
