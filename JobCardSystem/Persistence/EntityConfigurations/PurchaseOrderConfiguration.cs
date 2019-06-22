using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;
using JobCardSystem.Core.Domain;

namespace JobCardSystem.Persistence.EntityConfigurations
{
    public class PurchaseOrderConfiguration : EntityTypeConfiguration<PurchaseOrder>
    {
        public PurchaseOrderConfiguration()
        {
            HasKey(h => h.Id);

            HasMany(h => h.StockItems)
                .WithMany(w => w.PurchaseOrders)
                .Map(m =>
                {
                    m.ToTable("PurchaseOrderItems");
                    m.MapLeftKey("PurchaseOrderId");
                    m.MapRightKey("StockItemId");
                });
        }
    }
}