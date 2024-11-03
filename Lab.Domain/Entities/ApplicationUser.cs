using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab.Domain.Entities
{
    public class ApplicationUser : BaseEntity
    {       

        public virtual string Name { get; set; }
                
        public virtual string Email { get; set; }
                
        public virtual string UserName { get; set; }

        public virtual string Password { get; set; }        
    }
}
