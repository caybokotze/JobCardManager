using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;
using JobCardSystem.Core.Domain;

namespace JobCardSystem.Persistence.EntityConfigurations
{
    public class JobStatusHistoryConfigurations : EntityTypeConfiguration<JobStatusHistory>
    {
        public JobStatusHistoryConfigurations()
        {
            HasKey(k => k.Id);

            //HasRequired(req => req.JobCard).WithMany(many => many.JobStatusHistories).WillCascadeOnDelete(false);
        }
    }
}