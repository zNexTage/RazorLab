using Lab.Application.UseCases.User;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab.Application
{
    public static class ApplicationConfiguration
    {
        public static void AddApplication(this IServiceCollection services) {
            AddUserUseCases(services);
        }

        private static void AddUserUseCases(IServiceCollection services)
        {
            services.AddScoped<IRegisterUserUseCase, RegisterUserUseCase>();
        }
    }
}
