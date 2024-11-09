using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab.Domain.Repositories.User
{
    public interface IUserReadOnlyRepository<T> : IReadOnlyRepository<T>
    {
        public Task<bool> CheckEmail(string email);
    }
}
