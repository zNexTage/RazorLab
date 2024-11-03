using FluentNHibernate.Mapping;
using Lab.Domain.Entities;

namespace Lab.Infrastructure.Mapping
{
    public class UserMap : ClassMap<ApplicationUser>
    {
        public UserMap() {
            Table("Users");

            Id(m => m.Id)
                .Unique();            
            
            Map(m => m.Name)
                .Length(100)
                .Not.Nullable();                       

            Map(m => m.Password)
                .Length(100)
                .Not.Nullable();

            Map(m => m.Email)
                .Length(100)
                .Not.Nullable();

            Map(m => m.UserName)
                .Length(100)
                .Not.Nullable();

            Map(m => m.CreatedAt)
                .CustomSqlType("datetime");

            Map(m => m.UpdatedAt)
                .CustomSqlType("datetime");            
        }
    }
}
