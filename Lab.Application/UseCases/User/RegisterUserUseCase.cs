using AutoMapper;
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
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public RegisterUserUseCase(
            [FromKeyedServices("WUser")]IWriteOnlyRepository<ApplicationUser> repository,
            IMapper mapper,
            IUnitOfWork unitOfWork
            )
        {
            _repository = repository;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<ApplicationUser> Register(RequestUser requestUser)
        {
            var user = _mapper.Map<ApplicationUser>(requestUser);

            var result = await _repository.Create(user);

            await _unitOfWork.FlushAsync();

            return result;
        }
    }
}
