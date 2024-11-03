using Lab.Domain.Entities;
using Lab.Domain.Repositories;
using NHibernate;

namespace Lab.Infrastructure.DataAccess.Repositories.User
{
    /// <summary>
    /// Registra e atualiza um usuário.
    /// </summary>
    public class UserWriteOnlyRepository : IWriteOnlyRepository<ApplicationUser>
    {
        private readonly ISession _session;

        public UserWriteOnlyRepository(ISession session)
        {
            _session = session;
        }


        public async Task<ApplicationUser> Create(ApplicationUser obj)
        {
            var result = (string)await _session.SaveAsync(obj);
            await _session.FlushAsync();

            return obj;
        }

        public async Task<ApplicationUser> Update(ApplicationUser obj)
        {
            await _session.UpdateAsync(obj);
            await _session.FlushAsync();
            return obj;
        }
    }
}
