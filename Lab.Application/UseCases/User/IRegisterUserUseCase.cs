using Lab.Communication.Request.User;
using Lab.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab.Application.UseCases.User
{
    public interface IRegisterUserUseCase
    {
        public Task<ApplicationUser> Register(RequestUser requestUser);
    }
}
