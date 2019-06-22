using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JobCardSystem.Core.Domain
{
    public class PurchaseOrder
    {
        public int Id { get; set; }
        public int Quantity { get; set; }

        public int SupplierId { get; set; }

        #region Navigational Properties

        public virtual ICollection<StockItem> StockItems { get; set; }
        public virtual Supplier Supplier { get; set; }

        #endregion

    }
}