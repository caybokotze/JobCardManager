using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Threading;
using System.Web;
using JobCardSystem.Core.Domain;

namespace JobCardSystem.Persistence.EntityConfigurations
{
    public class StockConfiguration : EntityTypeConfiguration<StockItem>
    {
        public StockConfiguration()
        {
            Property(p => p.Id).IsRequired();

            Property(p => p.Name).IsRequired();

        }
    }
}