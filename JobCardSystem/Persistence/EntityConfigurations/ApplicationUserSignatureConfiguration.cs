using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;
using JobCardSystem.Core.Domain;

namespace JobCardSystem.Persistence.EntityConfigurations
{
    public class ApplicationUserSignatureConfiguration : EntityTypeConfiguration<ApplicationUserSignature>
    {
        public ApplicationUserSignatureConfiguration()
        {
            HasKey(k => k.Id);
            Property(p => p.ApplicationUserId).IsOptional();

            //HasRequired(r => r.StockItem).WithMany(w => w.PurchaseOrderItems).HasForeignKey(f => f.StockItemId);
        }
    }
}