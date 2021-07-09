using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace DemoProject.Data
{
    public abstract class Repository<TEntity, Tkey> : IRepository<TEntity, Tkey>
        where TEntity : class,IEntity<Tkey>
    {
        protected readonly DbContext _context;
        protected readonly DbSet<TEntity> _dbSet;
        public Repository(DbContext context)
        {
            _context = context;
            _dbSet = _context.Set<TEntity>();
        }
        public virtual void Add(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public virtual void Edit(TEntity entityToDelete)
        {
            throw new NotImplementedException();
        }

        public virtual IList<TEntity> Get(Expression<Func<TEntity, bool>> filter, string includeProperties = " ")
        {
            throw new NotImplementedException();
        }

        public virtual (IList<TEntity> data, int total, int totalDisplay) Get(Expression<Func<TEntity, bool>> filter = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, string includeProperties = " ", int pageIndex = 1, int pageSize = 10, bool isTrackingoff = false)
        {
            throw new NotImplementedException();
        }

        public virtual IList<TEntity> Get(Expression<Func<TEntity, bool>> filter = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, string includeProperties = " ", bool isTrackingOff = false)
        {
            throw new NotImplementedException();
        }

        public virtual IList<TEntity> GetAll()
        {
            return _dbSet.ToList();
        }

        public virtual TEntity GetById(Tkey id)
        {
            return _dbSet.Find(id);
        }

        public virtual int GetCount(Expression<Func<TEntity, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public virtual (IList<TEntity> data, int total, int totalDisplay) GetDynamic(Expression<Func<TEntity, bool>> filter = null, string orderby = null, string includeProperties = " ", int pageIndex = 1, int pageSize = 10, bool isTrackingoff = false)
        {
            throw new NotImplementedException();
        }

        public virtual IList<TEntity> GetDynamic(Expression<Func<TEntity, bool>> filter = null, string orderBy = null, string includeProperties = " ", bool isTrackingOff = false)
        {
            throw new NotImplementedException();
        }

        public virtual void Remove(Tkey id)
        {
            throw new NotImplementedException();
        }

        public virtual void Remove(TEntity entityToDelete)
        {
            throw new NotImplementedException();
        }

        public virtual void Remove(Expression<Func<TEntity, bool>> filter)
        {
            throw new NotImplementedException();
        }
    }
}
