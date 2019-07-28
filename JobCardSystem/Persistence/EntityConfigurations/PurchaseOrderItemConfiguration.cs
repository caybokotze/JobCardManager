using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;
using JobCardSystem.Core.Domain.Configurations;

namespace JobCardSystem.Persistence.EntityConfigurations
{
    public class PurchaseOrderItemConfiguration : EntityTypeConfiguration<PurchaseOrderItem>
    {
        public PurchaseOrderItemConfiguration()
        {
            HasKey(k => k.Id);
            HasRequired(r => r.StockItem).WithMany(w => w.PurchaseOrderItems).HasForeignKey(f => f.StockItemId);
            HasRequired(r => r.PurchaseOrder).WithMany(w => w.PurchaseOrderItems).HasForeignKey(f => f.PurchaseOrderId);
        }
    }
}