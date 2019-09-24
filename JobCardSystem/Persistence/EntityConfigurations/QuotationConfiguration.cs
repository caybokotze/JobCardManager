using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;
using JobCardSystem.Core.Domain;

namespace JobCardSystem.Persistence.EntityConfigurations
{
    public class QuotationConfiguration : EntityTypeConfiguration<Quotation>
    {
        public QuotationConfiguration()
        {
            HasKey(k => k.Id);

            Property(p => p.CreatedAt).IsRequired();


        }
    }
}