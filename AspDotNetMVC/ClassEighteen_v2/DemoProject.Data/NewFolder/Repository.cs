using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

//namespace DemoProject.Data
//{
    //public class Repository<T> : IRepository<T> where T : class
    //{
    //    protected readonly DbContext _context;
    //    protected readonly DbSet<T> _dbSet;
    //    public Repository(DbContext context)
    //    {
    //        _context = context;
    //        _dbSet = _context.Set<T>();
    //    }

    //    public virtual int GetCountM(Expression<Func<T,bool>> filter = null)
    //    {
    //        //
    //        // var query = _dbSet;
    //        IQueryable<T> q = null;
    //        var count = 0;
    //        if(filter != null)
    //        {
    //            q = _dbSet.Where(filter);
    //        }
    //        count = q.Count();
    //        return count;

    //    }  
    //    public virtual int GetCount(Expression<Func<T,bool>> filter = null)
    //    {
    //        IQueryable<T> q = _dbSet;       //sir k ask korte hobe _dbSet ki IQuarable type er hoye geche? IQusrsble type a rakhar jonno?
    //        var count = 0;                                    
    //        if(filter != null)
    //        {
    //            q = q.Where(filter);
    //        }
    //        count = q.Count();
    //        return count;

    //    }

    //    public void Add(T item)
    //    {
    //        _context.Set<T>().Add(item);
    //    }

    //    public void Get()
    //    {
    //        throw new NotImplementedException();
    //    }

    //    public IList<T> GetAll()
    //    {
    //        throw new NotImplementedException();
    //    }

    //    public void Remove()
    //    {
    //        throw new NotImplementedException();
    //    }

    //    public void Update()
    //    {
    //        throw new NotImplementedException();
    //    }
//    }
//}
