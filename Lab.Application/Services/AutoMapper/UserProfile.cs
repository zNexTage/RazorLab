using AutoMapper;
using Lab.Application.Utils;
using Lab.Communication.Request.User;
using Lab.Domain.Entities;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab.Application.Services.AutoMapper
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {            
            CreateMap<RequestUser, ApplicationUser>()
                .ForMember(opt => 
                opt.Password,
                opt =>
                {
                    opt.AddTransform(value => PasswordHasher.Encrypt(value));
                });
        }
    }
}
