using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab.Domain.Entities
{
    public abstract class BaseEntity
    {
        public virtual string Id { get; set; } = Guid.NewGuid().ToString();
        public virtual DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public virtual DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
    }
}
