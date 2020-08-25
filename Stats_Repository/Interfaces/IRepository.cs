using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Stats_Repository.Interfaces
{
    public interface IRepository<T> where T : class
    {
        void Add(T entity);
        void Add(IEnumerable<T> entities);
        void Update(T entity);
        void Update(IEnumerable<T> entities);
        void Delete(T entity);
        void Delete(IEnumerable<T> entities);
        IQueryable<T> All();
        T FindBy(Expression<Func<T, bool>> expression);
        T FindBy(int id);
        IQueryable<T> FilterBy(Expression<Func<T, bool>> expression);
    }
}