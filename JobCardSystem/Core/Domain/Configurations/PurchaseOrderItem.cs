using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JobCardSystem.Core.Domain.Configurations
{
    public class PurchaseOrderItem
    {
        /*
         * Note: For some unknown reason, creating this table as a FluentApi mapped table didn't work.
         * Therefore I created this custom configuration table that does the same thing.
         * To view the logical implementation of this file goto: PurchaseOrderItemConfiguration in the Entity Configurations folder.
         */

        public int Id { get; set; }
        public int PurchaseOrderId { get; set; }
        public int StockItemId { get; set; }
        public int AmountOfItems { get; set; }
        //
        public virtual StockItem StockItem { get; set; }
        public virtual PurchaseOrder PurchaseOrder { get; set; }
    }
}