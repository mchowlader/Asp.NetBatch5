﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DemoProject.Data
{
    public interface IRepository<TEntity, Tkey>
        where TEntity : class, IEntity<Tkey>
    {
        void Add(TEntity entity);
        void Remove(Tkey id);
        void Remove(TEntity entityToDelete);
        void Remove(Expression<Func<TEntity, bool>> filter);
        void Edit(TEntity entityToDelete);
        int GetCount(Expression<Func<TEntity, bool>> filter = null);
        IList<TEntity> Get(Expression<Func<TEntity, bool>> filter, string includeProperties = " ");
        IList<TEntity> GetAll();
        TEntity GetById(Tkey id);
        (IList<TEntity> data, int total, int totalDisplay) Get
            (Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            string includeProperties = " ", int pageIndex = 1, int pageSize = 10,bool isTrackingoff = false);
        (IList<TEntity> data, int total, int totalDisplay) GetDynamic
            (Expression<Func<TEntity, bool>> filter = null,
            string orderby = null,
            string includeProperties = " ", int pageIndex = 1, int pageSize = 10, bool isTrackingoff = false);
        IList<TEntity> Get(Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            string includeProperties = " ", bool isTrackingOff = false);
        IList<TEntity> GetDynamic(Expression<Func<TEntity, bool>> filter = null,
            string orderBy = null,
            string includeProperties = " ", bool isTrackingOff = false);




    }
}
