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

            HasRequired<JobStatus>(h => h.JobStatus);
            HasRequired<JobType>(h => h.JobType);

            //HasMany(h => h.StockItems)
            //    .WithMany(w => w.JobCards)
            //    .Map(m =>
            //    {
            //        m.ToTable("JobCardStockItems");
            //        m.MapLeftKey("JobCardId");
            //        m.MapRightKey("StockItemId");
            //    });


        }
    }
}