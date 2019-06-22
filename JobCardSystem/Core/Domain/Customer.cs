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

        public bool ActiveState { get; set; } = true;

        [Display(Name = "Customer Name")]
        public string Name { get; set; }
        [Display(Name = "Customer Address")]
        public string Address { get; set; }
        [Required(ErrorMessage = "Please enter customer email.")]
        [Display(Name = "Email Address:")]
        [EmailAddress]
        public string Customer_email { get; set; }
        public string Industry { get; set; }
        public string Client { get; set; }
        [Display(Name = "Contact Name")]
        public string Contact_Name { get; set; }
        [Required(ErrorMessage = "Contact number is a required field")]
        [MaxLength(10, ErrorMessage = "Maximum length is 10"), MinLength(10, ErrorMessage = "Minimum length is 10")]
        [Display(Name = "Contact Number")]
        public string Contact_Number { get; set; }
        [Required(ErrorMessage = "*Please enter contact email.")]
        [Display(Name = "Email Address:")]
        [EmailAddress]
        public string Contact_Email { get; set; }

        [Required(ErrorMessage = "*Please select if there is a Contract in place .")]
        [Display(Name = " Maintenance Contract")]
        public string MaintenanceContract { get; set; }

        [Display(Name = "Contract Duration")]
        public int ContractDuration { get; set; }

        [Display(Name = "Services Per a Month")]
        public string ServicesPerMonth { get; set; }

        #region Navigational Properties
        public virtual ICollection<JobCard> JobCards { get; set; }
        public virtual ICollection<ApplicationUser> ApplicationUsers { get; set; }
        public virtual ICollection<Quotation> Quotations { get; set; }
        public virtual ICollection<PaymentRecord> PaymentRecords { get; set; }
        public virtual ICollection<Signature> Signatures { get; set; }
        

        #endregion
    }
}