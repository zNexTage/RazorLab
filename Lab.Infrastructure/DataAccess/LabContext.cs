using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab.Infrastructure.DataAccess
{
    public class LabContext : DbContext
    {
        public LabContext(DbContextOptions<LabContext> options):base(options)
        {
            
        }

        public LabContext()
        {
            
        }
    }
}
