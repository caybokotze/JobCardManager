using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace JobCardSystem.Core.Domain
{
    public class StockItem
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Supplier Name")]
        public string Name { get; set; }

        [Display(Name = "Description")]
        public string Description { get; set; }

        [Required]
        [Display(Name = "Available Units")]
        public int QuantityAvailable { get; set; }

        [Required]
        [Display(Name = "Purchasing Cost")]
        public double Cost { get; set; }

        [Required]
        [Display(Name = "Selling Cost")]
        public double SellingPrice { get; set; }


        public virtual ICollection<Invoice> Invoices { get; set; }
        public virtual ICollection<Quotation> Quotations { get; set; }
        public virtual ICollection<Supplier> Suppliers { get; set; }
        public virtual ICollection<PurchaseOrder> PurchaseOrders { get; set; }
        public virtual ICollection<JobCard> JobCards { get; set; }
    }
}