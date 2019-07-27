using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Web;
using JobCardSystem.Core.Domain.Configurations;

namespace JobCardSystem.Core.Domain
{
    public class PurchaseOrder
    {
        public int Id { get; set; }

        public int SupplierId { get; set; }

        [DataType(DataType.Date)]
        public DateTime CreatedAt { get; set; } = DateTime.Now;

        #region Navigational Properties

        public virtual ICollection<PurchaseOrderItem> PurchaseOrderItems { get; set; }

        public virtual Supplier Supplier { get; set; }

        #endregion

    }
}