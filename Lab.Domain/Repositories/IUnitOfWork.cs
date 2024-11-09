using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab.Domain.Repositories
{
    public interface IUnitOfWork : IDisposable
    {       
        
        public Task FlushAsync();
    }
}
