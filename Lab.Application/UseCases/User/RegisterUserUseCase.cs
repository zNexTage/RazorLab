using AutoMapper;
using Lab.Communication.Request.User;
using Lab.Domain.Entities;
using Lab.Domain.Repositories;
using Lab.Domain.Repositories.User;
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
        private readonly IWriteOnlyRepository<ApplicationUser> _wRepository;
        private readonly IUserReadOnlyRepository<ApplicationUser> _rRepository;

        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public RegisterUserUseCase(
            [FromKeyedServices("WUser")]IWriteOnlyRepository<ApplicationUser> wRepository,
            IUserReadOnlyRepository<ApplicationUser> rRepository,
            IMapper mapper,
            IUnitOfWork unitOfWork
            )
        {
            _wRepository = wRepository;
            _rRepository = rRepository;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<ApplicationUser> Register(RequestUser requestUser)
        {
            var alreadyExists = await _rRepository.CheckEmail(requestUser.Email);

            if (alreadyExists) {
                throw new Exception("Já existe usuário com esse email");
            }

            var user = _mapper.Map<ApplicationUser>(requestUser);

            var result = await _wRepository.Create(user);

            await _unitOfWork.FlushAsync();

            return result;
        }
    }
}
