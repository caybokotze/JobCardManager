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
        public string Address { get; set; }

        [Display(Name = "Email")]
        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        //
        [Display(Name = "Contact Number")]
        [Required]
        [DataType(DataType.PhoneNumber)]
        public string ContactNumber { get; set; }

        public bool Delete { get; set; } = false;

        #region Navigational Properties
        public virtual ICollection<PurchaseOrder> PurchaseOrders { get; set; }
        public virtual ICollection<StockItem> StockItems { get; set; }
        #endregion
    }
}