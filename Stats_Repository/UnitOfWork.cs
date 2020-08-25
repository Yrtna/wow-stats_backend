using System;
using System.Data;
using NHibernate;
using Stats_Repository.Interfaces;

namespace Stats_Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ITransaction _transaction;

        private ISession Session { get; set; }

        public UnitOfWork(ISessionFactory sessionFactory)
        {
            Session = sessionFactory.OpenSession();

            Session.FlushMode = FlushMode.Auto;

            _transaction = Session.BeginTransaction(IsolationLevel.ReadCommitted);
        }

        public void Dispose()
        {
            if (Session.IsOpen)
                Session.Close();
        }

        public void Commit()
        {
            if(!_transaction.IsActive)
                throw new InvalidOperationException("No Active Transaction.");
            _transaction.Commit();
        }

        public void Rollback()
        {
            if(_transaction.IsActive)
               _transaction.Rollback(); 
        }
    }
}