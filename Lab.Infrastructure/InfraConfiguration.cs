using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using Lab.Infrastructure.DataAccess;
using Microsoft.Extensions.DependencyInjection;
using NHibernate.Cfg;
using NHibernate.Tool.hbm2ddl;
using System.Reflection;

namespace Lab.Infrastructure
{
    public static class InfraConfiguration
    {
        /// <summary>
        /// Cria as tabelas na base de dados.
        /// </summary>
        /// <param name="configuration"></param>
        private static void Migrate(Configuration configuration)
        {
            var exporter = new SchemaExport(configuration);
            exporter.Execute(false, true, false);
        }

        /// <summary>
        /// Configura o NHibernate para utilizar o SQL Server. Além disso, utilizando os mapeamentos das entidades, 
        /// é feito a criação das tabelas.
        /// </summary>
        /// <param name="servicesCollection"></param>
        /// <param name="connectionString"></param>
        public static void AddNHiberSqlServer(this IServiceCollection servicesCollection, string connectionString)
        {
            var assembly = typeof(InfraConfiguration).Assembly;

            var config = Fluently.Configure()
                .Database(MsSqlConfiguration.MsSql2012.ConnectionString(connectionString))
                .Mappings(m => m.FluentMappings.AddFromAssembly(assembly))
                .BuildConfiguration();

            Migrate(config);

            var factory = config.BuildSessionFactory();

            servicesCollection.AddScoped(opt =>
            {
                return factory.OpenSession();
            });
        }

    }
}
