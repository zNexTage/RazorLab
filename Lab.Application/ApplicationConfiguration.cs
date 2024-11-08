using Lab.Application.Services.AutoMapper;
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

            AddAutoMapper(services);
        }

        private static void AddUserUseCases(IServiceCollection services)
        {
            services.AddScoped<IRegisterUserUseCase, RegisterUserUseCase>();
        }

        private static void AddAutoMapper(IServiceCollection services) {
            var mapper = new AutoMapper.MapperConfiguration(options =>
            {
                options.AddProfile(new AutoMapping());
            }).CreateMapper();

            services.AddScoped(opt => mapper);
        }
    }
}
