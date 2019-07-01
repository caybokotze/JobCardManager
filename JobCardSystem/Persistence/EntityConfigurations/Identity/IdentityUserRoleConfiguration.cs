
using System.Data.Entity.ModelConfiguration;
using Microsoft.AspNet.Identity.EntityFramework;

namespace JobCardSystem.Persistence.EntityConfigurations.Identity
{
    public class IdentityUserRoleConfiguration : EntityTypeConfiguration<IdentityUserRole>
    {
        public IdentityUserRoleConfiguration()
        {
            HasKey(k => new
            {
                k.UserId,
                k.RoleId
            });

        }
    }
}