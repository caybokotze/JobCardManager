using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;
using JobCardSystem.Core.Domain;

namespace JobCardSystem.Persistence.EntityConfigurations
{
    public class SupplierConfiguration : EntityTypeConfiguration<Supplier>
    {
        public SupplierConfiguration()
        {
            HasKey(k => k.Id);

            HasMany(h => h.StockItems)
                .WithMany(w => w.Suppliers)
                .Map(m =>
                {
                    m.ToTable("SupplierItems");
                    m.MapLeftKey("SupplierId");
                    m.MapRightKey("StockItemId");
                });
        }
    }
}