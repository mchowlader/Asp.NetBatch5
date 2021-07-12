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
        protected readonly DbContext _dbContext;
        protected readonly DbSet<TEntity> _dbSet;
        public Repository(DbContext dbContext)
        {
            _dbContext = dbContext;
            _dbSet = _dbContext.Set<TEntity>();
        }
        public void Add(TEntity entity)
        {
            _dbSet.Add(entity);
        }

        public void Edit(TEntity entityToDelete)
        {
            throw new NotImplementedException();
        }

        public IList<TEntity> Get(Expression<Func<TEntity, bool>> filter, string includeProperties = " ")
        {
            throw new NotImplementedException();
        }

        public (IList<TEntity> data, int total, int totalDisplay) Get(Expression<Func<TEntity, bool>> filter = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, string includeProperties = " ", int pageIndex = 1, int pageSize = 10, bool isTrackingoff = false)
        {
            throw new NotImplementedException();
        }

        public IList<TEntity> Get(Expression<Func<TEntity, bool>> filter = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, string includeProperties = " ", bool isTrackingOff = false)
        {
            throw new NotImplementedException();
        }

        public IList<TEntity> GetAll()
        {
            return _dbSet.ToList();
        }

        public TEntity GetById(Tkey id)
        {
            throw new NotImplementedException();
        }

        public int GetCount(Expression<Func<TEntity, bool>> filter = null)
        {
            IQueryable<TEntity> query = _dbSet;
            var count = 0;
            if (filter != null)
            {
                query = query.Where(filter);
            }
            count = query.Count();
            return count;
        }

        public (IList<TEntity> data, int total, int totalDisplay) GetDynamic(Expression<Func<TEntity, bool>> filter = null, string orderby = null, string includeProperties = " ", int pageIndex = 1, int pageSize = 10, bool isTrackingoff = false)
        {
            throw new NotImplementedException();
        }

        public IList<TEntity> GetDynamic(Expression<Func<TEntity, bool>> filter = null, string orderBy = null, string includeProperties = " ", bool isTrackingOff = false)
        {
            throw new NotImplementedException();
        }

        public void Remove(Tkey id)
        {
            throw new NotImplementedException();
        }

        public void Remove(TEntity entityToDelete)
        {
            throw new NotImplementedException();
        }

        public void Remove(Expression<Func<TEntity, bool>> filter)
        {
            throw new NotImplementedException();
        }
    }
}
