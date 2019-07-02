﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
        [Required(ErrorMessage = "Please select a value from the drop down list.")]
        public int ServicesId { get; set; }
        public virtual ServiceContract ServiceContract { get; set; }
        #endregion

        #region Navigational Properties
        public virtual ICollection<JobCard> JobCards { get; set; }
        public virtual ICollection<Quotation> Quotations { get; set; }
        public virtual ICollection<PaymentRecord> PaymentRecords { get; set; }
        public virtual ICollection<Signature> Signatures { get; set; }
        #endregion
    }
}