using System;
using System.Configuration;
using System.Data;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using NHibernate.Tool.hbm2ddl;
using WCL_Api_Library;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using NHibernateDbSetup.DTO;
using Stats_Repository;
using Stats_Repository.Mappings;
using WCL_Api_Library.DTO;
using Encounter = NHibernateDbSetup.DTO.Encounter;

namespace NHibernateDbSetup
{
    class Program
    {
        private static ISessionFactory _sessionFactory;

        static void Main(string[] args)
        {
            // string connectionString = ConfigurationManager.ConnectionStrings["wowstats_azure"].ConnectionString;
            // CreateDatabase(connectionString);
            // SetupDb().Wait();
            SetupDb(true).Wait();
        }

        // private static void TestRepository(bool export = false)
        // {
        //     if (export)
        //         CreateDatabase(ConfigurationManager.ConnectionStrings["wowstats_azure"].ConnectionString, export);
        //     var repo = new StatsRepository();
        //     
        //     // WCL Api Library
        //     var wclApi = new WCL_Api();
        //     var zones = wclApi.GetZonesAsync().Result;
        //     var newZones = zones.Select(s => s.ToZone()).ToList();
        //     repo.Zones.Add(newZones);
        //
        //     // using ISession session = _sessionFactory.OpenSession();
        //     // var encounters = session.Query<Encounter>().Where(s=>s.Zone.Name == "Molten Core").ToList();
        //     var x = 30;
        // }

        private static async Task SetupDb(bool export = false)
        {
            // CreateDatabase(connectionString, true);
            CreateDatabase(ConfigurationManager.ConnectionStrings["wowstats_azure"].ConnectionString, export);
            Console.WriteLine("DB created");

            await ExportZones();
            await ExportClasses();
        }

        private static async Task ExportZones()
        {
            // WCL Api Library
            var wclApi = new WCL_Api();
            var repo = new StatsRepository();

            // Get Zones and Upload to DB
            var zones = wclApi.GetZonesAsync().Result;
            var newZones = zones.Select(s => s.ToZone()).ToList();
            repo.Zones.Add(newZones);
        }

        private static async Task ExportClasses()
        {
            // WCL Api Library
            var wclApi = new WCL_Api();
            var repo = new StatsRepository();

            // Get Classes and Upload to DB
            var classes = wclApi.GetClassicClassesAsync().Result;
            var newClasses = classes.Select(s => s.ToClassicClass()).ToList();
            repo.Classes.Add(newClasses);
        }

        private static void CreateDatabase(string connectionString, bool export = false)
        {
            var configuration = Fluently.Configure()
                .Database(MsSqlConfiguration.MsSql2012.ConnectionString(connectionString).ShowSql)
                .Mappings(m => m.FluentMappings
                    .AddFromAssemblyOf<StatsRepository>()
                )
                .BuildConfiguration();

            if (export)
            {
                var exporter = new SchemaExport(configuration);
                exporter.Execute(true, true, false);
            }

            _sessionFactory = configuration.BuildSessionFactory();
        }
    }
}