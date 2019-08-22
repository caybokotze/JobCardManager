
using System.Data.Entity.ModelConfiguration;
using JobCardSystem.Core.Domain;

namespace JobCardSystem.Persistence.EntityConfigurations.Identity
{
    public class ApplicationUserConfiguration : EntityTypeConfiguration<ApplicationUser>
    {
        public ApplicationUserConfiguration()
        {
            HasKey<string>(h => h.Id);

            HasRequired(r => r.Area);



            HasMany(c => c.JobCards)
                .WithMany(s => s.ApplicationUsers)
                .Map(m =>
                {
                    m.ToTable("UserJobCards");
                    m.MapLeftKey("ApplicationUserId");
                    m.MapRightKey("JobCardId");

                });

        }
    }
}