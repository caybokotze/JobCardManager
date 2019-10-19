using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using JobCardSystem.Core.Domain.Configurations;

namespace JobCardSystem.Core.Domain
{
    public class StockItem
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Item Name")]
        public string Name { get; set; }

        [Display(Name = "Description")]
        public string Description { get; set; }

        [Required]
        [Display(Name = "Available Units")]
        [Range(0, 10000)]
        public int QuantityAvailable { get; set; }

        [Required]
        [Display(Name = "Purchasing Cost")]
        [Range(0,10000)]
        public double Cost { get; set; }

        [Required]
        [Display(Name = "Selling Cost")]
        [Range(0, 10000)]
        public double SellingPrice { get; set; }

        public string FileDir { get; set; }

        public int LimitWarning { get; set; } = 5;

        //[NotMapped]
        [ForeignKey("Supplier")]
        public int SupplierId { get; set; }
        //

        public bool FlagCheck { get; set; } = false;

        public bool Deleted { get; set; } = false;
        
        public virtual Supplier Supplier { get; set; }

        public virtual ICollection<Invoice> Invoices { get; set; }
        public virtual ICollection<PurchaseOrderItem> PurchaseOrderItems { get; set; }
        //public virtual ICollection<JobCard> JobCards { get; set; }
    }
}