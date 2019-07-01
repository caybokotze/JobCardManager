
using System.Data.Entity.ModelConfiguration;
using Microsoft.AspNet.Identity.EntityFramework;

namespace JobCardSystem.Persistence.EntityConfigurations.Identity
{
    public class IdentityRoleConfiguration : EntityTypeConfiguration<IdentityRole>
    {
        public IdentityRoleConfiguration()
        {
            HasKey<string>(k => k.Id);

            
        }
    }
}