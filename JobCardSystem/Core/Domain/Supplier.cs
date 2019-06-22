using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace JobCardSystem.Core.Domain
{
    public class Supplier
    {
        [Key]
        public int Id { get; set; }
        [Display(Name = "Supplier Name")]
        [Required]
        public string Name { get; set; }
        [Display(Name = "Supplier Address")]
        [Required]
        public string Address { get; set; }
        [Display(Name = "Supplier Email")]
        [Required]
        public string Email { get; set; }
        [Display(Name = "Supplier Contact Number")]
        [Required]
        public string ContactNumber { get; set; }

        #region Navigational Properties

        public virtual ICollection<PurchaseOrder> PurchaseOrders { get; set; }
        public virtual ICollection<StockItem> StockItems { get; set; }

        #endregion
    }
}