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

            Property(p => p.CreatedAt).HasColumnType("DateTime2");
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
            

        }
    }
}