using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;
using JobCardSystem.Core.Domain;
using StructureMap.Building;

namespace JobCardSystem.Persistence.EntityConfigurations
{
    public class JobCardConfiguration : EntityTypeConfiguration<JobCard>
    {
        public JobCardConfiguration()
        {
            HasKey(k => k.Id);

            
        }
    }
}