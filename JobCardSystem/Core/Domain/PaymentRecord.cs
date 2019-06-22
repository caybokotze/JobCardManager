using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Web;

namespace JobCardSystem.Core.Domain
{
    public class PaymentRecord
    {
        public int Id { get; set; }
        public DateTime PaymentDate { get; set; }
        public double FullAmount { get; set; }

        public int PaymentTypeId { get; set; }
        public int InvoiceId { get; set; }

        #region Navigational Properties

        public virtual PaymentType PaymentType { get; set; }
        public virtual Invoice Invoice { get; set; }
        public virtual ICollection<Customer> Customers { get; set; }

        #endregion

    }
}