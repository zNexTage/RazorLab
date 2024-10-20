using Lab.Infrastructure.DataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Lab.Infrastructure
{
    public static class InfraConfiguration
    {
        public static void AddSqlServerContext(this IServiceCollection servicesCollection, string connectionString)
        {
            servicesCollection.AddDbContext<LabContext>(opts =>
            {
                opts.UseSqlServer(connectionString);
            });
        }

        public static void CheckDbConnection(this IServiceProvider provider)
        {
            var scope = provider.CreateScope();

            var context = scope.ServiceProvider.GetRequiredService<LabContext>();

            if (!context.Database.CanConnect())
            {
                throw new Exception("Não foi possível se conectar com a base de dados. Verifique a connection string.");
            }
        }

    }
}
