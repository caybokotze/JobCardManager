using System.Data.Entity.ModelConfiguration;
using JobCardSystem.Core.Domain;

namespace JobCardSystem.Persistence.EntityConfigurations
{
    public class AreaConfiguration : EntityTypeConfiguration<Area>
    {
        public AreaConfiguration()
        {
            HasKey(k => k.Id);
            
        }
    }
}