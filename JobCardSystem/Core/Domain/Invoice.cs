using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace JobCardSystem.Core.Domain
{
    public class Invoice
    {
        [Key]
        public int Id { get; set; }
        public DateTime DateTime { get; set; }
        public int JobCardId { get; set; }

        #region Navigational Properties

        public virtual ICollection<StockItem> StockItems { get; set; }
        public virtual JobCard JobCard { get; set; }

        #endregion

    }
}