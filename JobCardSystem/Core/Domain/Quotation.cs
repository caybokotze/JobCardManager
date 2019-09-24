using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Web;

namespace JobCardSystem.Core.Domain
{
    public class Quotation
    {
        public int Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public string Description { get; set; }
        public double Total { get; set; }
        public bool Approve { get; set; } = false;

        public bool IsActive { get; set; } = true;
        //
        public int CustomerId { get; set; }
        #region Navigational Properties
        //
        public Customer Customer { get; set; }
        public virtual ICollection<StockItemQuantity> StockItemQuantities { get; set; }
        //
        #endregion
    }

    public class StockItemQuantity
    {
        public int Id { get; set; }
        
        public int QuotationId { get; set; }
        public int StockItemId { get; set; }
        public int Quantity { get; set; }

        #region Mappings

        public virtual Quotation Quotation { get; set; }
        public virtual StockItem StockItem { get; set; }

        #endregion
    }
}