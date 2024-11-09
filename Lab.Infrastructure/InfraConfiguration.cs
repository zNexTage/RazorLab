using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using Lab.Domain.Entities;
using Lab.Domain.Repositories;
using Lab.Infrastructure.DataAccess.Configuration;
using Lab.Infrastructure.DataAccess.Repositories.User;
using Microsoft.Extensions.DependencyInjection;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Tool.hbm2ddl;

namespace Lab.Infrastructure
{
    public static class InfraConfiguration
    {
        public static void AddInfra(this IServiceCollection servicesCollection, string connectionString)
        {
            AddNHiberSqlServer(servicesCollection, connectionString);

            AddRepositories(servicesCollection);
        }

        private static void AddRepositories(IServiceCollection servicesCollection) {
            servicesCollection.AddKeyedScoped<IWriteOnlyRepository<ApplicationUser>, UserWriteOnlyRepository>("WUser");
        }



        /// <summary>
        /// Cria as tabelas na base de dados.
        /// </summary>
        /// <param name="configuration"></param>
        private static void Migrate(Configuration configuration)
        {
            var exporter = new SchemaUpdate(configuration);
            exporter.Execute(false, true);
        }

        /// <summary>
        /// Configura o NHibernate para utilizar o SQL Server. Além disso, utilizando os mapeamentos das entidades, 
        /// é feito a criação das tabelas.
        /// </summary>
        /// <param name="servicesCollection"></param>
        /// <param name="connectionString"></param>
        private static void AddNHiberSqlServer(IServiceCollection servicesCollection, string connectionString)
        {
            var assembly = typeof(NHiberSessionFactory).Assembly;
            var configuration = Fluently.Configure()
                .Database(MsSqlConfiguration.MsSql2012.ConnectionString(connectionString))
                .Mappings(m => m.FluentMappings.AddFromAssembly(assembly))
                .BuildConfiguration();

            Migrate(configuration);

            var sessionFactory = configuration.BuildSessionFactory();

            servicesCollection.AddScoped<IUnitOfWork, NHiberUnitOfWork>();
            servicesCollection.AddScoped<ISession>(opt => sessionFactory.OpenSession());
        }

    }
}
