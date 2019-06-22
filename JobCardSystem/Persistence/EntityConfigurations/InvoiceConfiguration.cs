using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;
using JobCardSystem.Core.Domain;

namespace JobCardSystem.Persistence.EntityConfigurations
{
    public class InvoiceConfiguration : EntityTypeConfiguration<Invoice>
    {
        public InvoiceConfiguration()
        {
            HasKey(k => k.Id);

            HasMany(c => c.StockItems)
                .WithMany(s => s.Invoices)
                .Map(m =>
                {
                    m.ToTable("InvoiceItems");
                    m.MapLeftKey("InvoiceId");
                    m.MapRightKey("StockItemId");
                });

            //HasMany(h => h.JobCards)
            //    .WithMany(s => s.Invoices)
            //    .Map(m =>
            //    {
            //        m.ToTable("InvoiceJobCards");
            //        m.MapLeftKey("InvoiceId");
            //        m.MapRightKey("JobCardId");
            //    });

        }


    }
}