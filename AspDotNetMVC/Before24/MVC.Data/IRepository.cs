using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MVC.Data
{
    public interface IRepository<TEntity, Tkey>
        where TEntity : class, IEntity<Tkey>
    {
        void Add(TEntity entity);
        IList<TEntity> GetAll();
        int GetCount(Expression<Func<TEntity, bool>> filter = null);
    }
}
