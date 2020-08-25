using System.Configuration;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using Stats_Repository.DTO;
using Stats_Repository.Mappings;
using Configuration = NHibernate.Cfg.Configuration;

namespace Stats_Repository
{
    public class NHibernateHelper
    {
        private ISessionFactory _sessionFactory;
        private Configuration _dbConfiguration;
        
        private ISessionFactory SessionFactory => _sessionFactory ??= CreateSessionFactory();

        public NHibernateHelper()
        {
            var connectionString = ConfigurationManager.ConnectionStrings["wowstats_azure"].ConnectionString;
            _dbConfiguration = Fluently.Configure()
                .Database(MsSqlConfiguration.MsSql2012.ConnectionString(connectionString).ShowSql)
                .Mappings(m => m.FluentMappings.AddFromAssemblyOf<ZoneMappings>())
                .BuildConfiguration();
        }

        private ISessionFactory CreateSessionFactory()
        {
            return _dbConfiguration.BuildSessionFactory();
        }

        public ISession OpenSession()
        {
            return SessionFactory.OpenSession();
        }
    }
}