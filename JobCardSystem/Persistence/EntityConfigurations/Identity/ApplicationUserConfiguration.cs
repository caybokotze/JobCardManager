
using System.Data.Entity.ModelConfiguration;
using JobCardSystem.Core.Domain;

namespace JobCardSystem.Persistence.EntityConfigurations.Identity
{
    public class ApplicationUserConfiguration : EntityTypeConfiguration<ApplicationUser>
    {
        public ApplicationUserConfiguration()
        {
            HasKey<string>(h => h.Id);

            HasOptional(p => p.Area);

            Property(p => p.AreaId).IsOptional();

            HasMany(h => h.Signatures)
                .WithMany(w => w.ApplicationUsers)
                .Map(m =>
                {
                    m.ToTable("UserSignatures");
                    m.MapLeftKey("ApplicationUserId");
                    m.MapRightKey("SignatureId");
                });

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