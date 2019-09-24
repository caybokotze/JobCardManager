using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace JobCardSystem.Core.Domain
{
    public class Customer
    {
        #region Properties

        public int Id { get; set; }

        public DateTime CreatedAt { get; set; }

        [Display(Name = "Customer Name")]
        [Required]
        public string Name { get; set; }

        [Display(Name = "Customer Surname")]
        [Required]
        public string Surname { get; set; }

        [Display(Name = "Customer Address")]
        public string Address { get; set; }

        [Required(ErrorMessage = "Please enter customer email.")]
        [Display(Name = "Email Address:")]
        [EmailAddress]
        public string Email { get; set; }

        [Display(Name = "Industry")]
        public string Industry { get; set; }

        [Display(Name = "Cellphone Number")]
        [StringLength(11)]
        [Required]
        public string CellNumber { get; set; }

        [Required(ErrorMessage = "Please select a contract from the drop down list.")]
        [Display(Name = "Maintenance Contract")]
        public int MaintenanceContractId { get; set; }

        public virtual MaintenanceContract MaintenanceContract { get; set; }

        [Display(Name = "Services Per Month")]
        public int ServiceContractId { get; set; }

        public virtual ServiceContract ServiceContract { get; set; }
        #endregion

        #region Navigational Properties
        public virtual ICollection<JobCard> JobCards { get; set; }
        //public virtual ICollection<Quotation> Quotations { get; set; }
        public virtual ICollection<PaymentRecord> PaymentRecords { get; set; }

        /*
         * Customer is also linked with a non compulsory signature, which is why it is referenced from the signature entity
         * and not the customer entity.
         */
        #endregion
    }
}