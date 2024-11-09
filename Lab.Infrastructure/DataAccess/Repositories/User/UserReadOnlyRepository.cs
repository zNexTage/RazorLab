using Lab.Domain.Entities;
using Lab.Domain.Repositories;
using Lab.Domain.Repositories.User;
using NHibernate;
using NHibernate.Linq;
using NHibernate.Util;

namespace Lab.Infrastructure.DataAccess.Repositories.User
{
    public class UserReadOnlyRepository : IUserReadOnlyRepository<ApplicationUser>
    {
        private readonly ISession _session;

        public UserReadOnlyRepository(ISession session)
        {
            _session = session;
        }

        public async Task<bool> CheckEmail(string email)
        {
            return await _session.Query<ApplicationUser>()
                .Where(user => user.Email == email)
                .AnyAsync();
        }

        Task<List<ApplicationUser>> IReadOnlyRepository<ApplicationUser>.GetAll()
        {
            throw new NotImplementedException();
        }

        Task<ApplicationUser> IReadOnlyRepository<ApplicationUser>.GetById(object id)
        {
            throw new NotImplementedException();
        }
    }
}
