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
            HasKey(k => k.Id);

        }
    }
}