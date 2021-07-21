using System;

namespace MVC.Data
{
    public interface IUnitOfWork : IDisposable
    {
        void Save();
    }
}
