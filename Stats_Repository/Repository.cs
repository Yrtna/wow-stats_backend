using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using NHibernate;
using Stats_Repository.Interfaces;

namespace Stats_Repository
{
    public abstract class Repository<T> : IRepository<T> where T : class
    {
        protected readonly ISession Session;

        protected Repository()
        {
            Session = new NHibernateHelper().OpenSession();
        }

        public void Add(T entity)
        {
            Session.Save(entity);
        }

        public void Add(IEnumerable<T> entities)
        {
            foreach (var entity in entities)
            {
                Session.Save(entity);
            }
        }

        public void Update(T entity)
        {
            Session.Update(entity);
        }

        public void Update(IEnumerable<T> entities)
        {
            foreach (var entity in entities)
            {
                Session.Update(entity);
            }
        }

        public void Delete(T entity)
        {
            Session.Delete(entity);
        }

        public void Delete(IEnumerable<T> entities)
        {
            foreach (var entity in entities)
            {
                Session.Delete(entity);
            }
        }

        public IQueryable<T> All()
        {
            return Session.Query<T>();
        }

        public T FindBy(Expression<Func<T, bool>> expression)
        {
            return FilterBy(expression).Single();
        }

        public T FindBy(int id)
        {
            return Session.Get<T>(id);
        }

        public IQueryable<T> FilterBy(Expression<Func<T, bool>> expression)
        {
            return All().Where(expression).AsQueryable();
        }
    }
}