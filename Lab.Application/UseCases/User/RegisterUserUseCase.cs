using Lab.Communication.Request.User;
using Lab.Domain.Entities;
using Lab.Domain.Repositories;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab.Application.UseCases.User
{
    public class RegisterUserUseCase : IRegisterUserUseCase
    {
        private readonly IWriteOnlyRepository<ApplicationUser> _repository;

        public RegisterUserUseCase([FromKeyedServices("WUser")]IWriteOnlyRepository<ApplicationUser> repository)
        {
            _repository = repository;
        }

        public async Task<ApplicationUser> Register(RequestUser requestUser)
        {
            var user = new ApplicationUser()
            {
                Name = requestUser.Name,
                Email = requestUser.Email,
                Password = requestUser.Password,
                UserName = requestUser.UserName
            };

            return await _repository.Create(user);
        }
    }
}
