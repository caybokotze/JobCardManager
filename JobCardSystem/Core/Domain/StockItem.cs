using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace JobCardSystem.Core.Domain
{
    public class StockItem
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Invoice> Invoices { get; set; }
        public virtual ICollection<Quotation> Quotations { get; set; }
        public virtual ICollection<Supplier> Suppliers { get; set; }
        public virtual ICollection<PurchaseOrder> PurchaseOrders { get; set; }
    }
}