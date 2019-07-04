using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;
using JobCardSystem.Core.Domain;

namespace JobCardSystem.Persistence.EntityConfigurations
{
    public class CustomerConfiguration : EntityTypeConfiguration<Customer>
    {
        public CustomerConfiguration()
        {
            HasKey<int>(h => h.Id);

            //HasRequired(h => h.ServiceContract);
            HasMany(h => h.Signatures)
                .WithMany(w => w.Customers)
                .Map(m =>
                {
                    m.ToTable("CustomerSignatures");
                    m.MapLeftKey("CustomerId");
                    m.MapRightKey("SignatureId");
                });
            //
            HasMany(h => h.PaymentRecords)
                .WithMany(m => m.Customers)
                .Map(m =>
                {
                    m.ToTable("CustomerPayments");
                    m.MapLeftKey("CustomerId");
                    m.MapRightKey("PaymentId");
                });
            //
            HasMany(h => h.Quotations)
                .WithMany(w => w.Customers)
                .Map(m =>
                {
                    m.ToTable("CustomerQuotes");
                    m.MapLeftKey("CustomerId");
                    m.MapRightKey("QuotationId");
                });

        }
    }
}