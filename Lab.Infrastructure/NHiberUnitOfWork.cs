using Lab.Domain.Repositories;
using NHibernate;

namespace Lab.Infrastructure
{
    /// <summary>
    /// Gerencia transações, ações de escrita e remoção na base de dados, reduzindo o número de 
    /// vezes que a base de dados é invocada.
    /// </summary>
    public class NHiberUnitOfWork : IUnitOfWork
    {
        private ISession _session;

        public NHiberUnitOfWork(ISession session)
        {
            _session = session;
        }        

        public async Task FlushAsync()
        {
            await _session.FlushAsync();
        }

        public void Dispose()
        {
            if( _session != null && _session.IsConnected)
            {
                _session.Dispose();
                _session = null;
            }
        }
    }
}
