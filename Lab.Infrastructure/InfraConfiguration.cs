using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using Lab.Domain.Entities;
using Lab.Domain.Repositories;
using Lab.Domain.Repositories.User;
using Lab.Infrastructure.DataAccess.Repositories.User;
using Microsoft.Extensions.DependencyInjection;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.SqlCommand;
using NHibernate.Tool.hbm2ddl;
using System.Diagnostics;

namespace Lab.Infrastructure
{
    public class SqlDebugOutputInterceptor : EmptyInterceptor
    {
        public override SqlString OnPrepareStatement(SqlString sql)
        {
            Debug.Write("NHibernate: ");
            Debug.WriteLine(sql);

            return base.OnPrepareStatement(sql);
        }
    }

    public static class InfraConfiguration
    {
        public static void AddInfra(this IServiceCollection servicesCollection, string connectionString)
        {
            AddNHiberSqlServer(servicesCollection, connectionString);

            AddRepositories(servicesCollection);
        }

        private static void AddRepositories(IServiceCollection servicesCollection) {
            servicesCollection.AddKeyedScoped<IWriteOnlyRepository<ApplicationUser>, UserWriteOnlyRepository>("WUser");
            servicesCollection.AddScoped<IUserReadOnlyRepository<ApplicationUser>, UserReadOnlyRepository>();
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
            var assembly = typeof(InfraConfiguration).Assembly;
            var configuration = Fluently.Configure()
                .Database(MsSqlConfiguration.MsSql2012.ConnectionString(connectionString))
                .Mappings(m => m.FluentMappings.AddFromAssembly(assembly))
                .BuildConfiguration();

            Migrate(configuration);

            var sessionFactory = configuration.BuildSessionFactory();

            servicesCollection.AddScoped<IUnitOfWork, NHiberUnitOfWork>();
            servicesCollection.AddScoped<ISession>(opt =>
            {
                var interceptor = new SqlDebugOutputInterceptor();

                if (true)
                {
                    return sessionFactory
                    .WithOptions()
                    .Interceptor(interceptor)
                    .OpenSession();
                }
                else
                {
                    return sessionFactory.OpenSession();
                }
            });            
        }

    }
}
