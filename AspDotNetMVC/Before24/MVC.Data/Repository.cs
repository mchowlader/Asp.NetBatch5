using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MVC.Data
{
    public class Repository<TEntity, Tkey> : IRepository<TEntity, Tkey>
          where TEntity : class, IEntity<Tkey>
    {
        private readonly DbContext _dbContext;
        private readonly DbSet<TEntity> _dbSet;
        public Repository(DbContext dbContext)
        {
            _dbContext = dbContext;
            _dbSet = _dbContext.Set<TEntity>();
        }
        public void Add(TEntity entity)
        {
            _dbSet.Add(entity);
        }

        public IList<TEntity> GetAll()
        {
            return _dbSet.ToList();
        }

        public int GetCount(Expression<Func<TEntity, bool>> filter = null)
        {
            IQueryable<TEntity> query = _dbSet;
            var count = 0;
            if(filter != null)
            {
                query = query.Where(filter);
            }
            count = query.Count();
            return count;
        }
    }
}
