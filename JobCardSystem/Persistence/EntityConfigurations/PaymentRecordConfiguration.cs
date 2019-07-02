using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;
using JobCardSystem.Core.Domain;

namespace JobCardSystem.Persistence.EntityConfigurations
{
    public class PaymentRecordConfiguration : EntityTypeConfiguration<PaymentRecord>
    {
        public PaymentRecordConfiguration()
        {
            HasKey(k => k.Id);

            Property(p => p.PaymentTypeId)
                .IsRequired();

            Property(p => p.InvoiceId)
                .IsRequired();

        }
    }
}