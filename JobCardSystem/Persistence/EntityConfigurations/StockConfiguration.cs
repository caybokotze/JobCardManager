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
            HasKey(k => k.Id);

            HasRequired(r => r.Supplier).WithMany(w => w.StockItems).HasForeignKey(f => f.SupplierId).WillCascadeOnDelete(false);
            /* Note:
             
            Disabling cascading delete will result in a null supplier entity foreign key value.
            Not doing this means that we will need to configure a cascading delete policy for all the related items, which will be quite time consuming.
            This is not necessarily desirable because if it happens all related items will also be deleted.
            This can result in some un-foreseen consequences.
            Therefore enforcing a null cascading value is the best option as there is no better alternative.
            The result of this is that when we delete a supplier the products belonging to that supplier will have a null foreign key where the supplierId value used to be.

             */

        }
    }
}