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

            HasMany(h => h.Customers)
                .WithMany(w => w.JobCards)
                .Map(m =>
                {
                    m.ToTable("JobCardCustomers");
                    m.MapLeftKey("JobCardId");
                    m.MapRightKey("CustomerId");
                });

            HasMany(h => h.StockItems)
                .WithMany(w => w.JobCards)
                .Map(m =>
                {
                    m.ToTable("JobCardStockItems");
                    m.MapLeftKey("JobCardId");
                    m.MapRightKey("StockItemId");
                });


        }
    }
}