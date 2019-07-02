using System.Data.Entity.ModelConfiguration;
using JobCardSystem.Core.Domain;

namespace JobCardSystem.Persistence.EntityConfigurations
{
    public class JobStatusConfiguration : EntityTypeConfiguration<JobStatus>
    {
        public JobStatusConfiguration()
        {
            
        }
    }
}