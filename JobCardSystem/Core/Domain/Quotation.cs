using System;
using System.Collections.Generic;
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

        #region Navigational Properties

        public virtual ICollection<StockItem> StockItems { get; set; }
        public virtual ICollection<Customer> Customers { get; set; }

        #endregion
    }
}