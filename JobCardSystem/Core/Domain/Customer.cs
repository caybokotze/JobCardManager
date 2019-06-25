using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace JobCardSystem.Core.Domain
{
    public class Customer
    {
        [Key]
        public int Id { get; set; }

        public DateTime CreatedAt { get; set; }

        [Display(Name = "Customer Name")]
        public string Name { get; set; }
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
        public string CellNumber { get; set; }

        [Required(ErrorMessage = "Please select a contract from the drop down list.")]
        [Display(Name = "Maintenance Contract")]
        public int MaintenanceContractId { get; set; }
        public virtual MaintenanceContract MaintenanceContract { get; set; }

        [Display(Name = "Contract Duration")]
        [Required(ErrorMessage = "Please select a value from the drop down list.")]
        public int ContractDurationId { get; set; }
        public virtual ContractDuration ContractDuration { get; set; }

        [Display(Name = "Services Per Month")]
        [Required(ErrorMessage = "Please select a value from the drop down list.")]
        public int ServicesId { get; set; }
        public virtual ServiceContract ServiceContract { get; set; }

        #region Navigational Properties
        public virtual ICollection<JobCard> JobCards { get; set; }
        public virtual ICollection<ApplicationUser> ApplicationUsers { get; set; }
        public virtual ICollection<Quotation> Quotations { get; set; }
        public virtual ICollection<PaymentRecord> PaymentRecords { get; set; }
        public virtual ICollection<Signature> Signatures { get; set; }
        #endregion
    }
}