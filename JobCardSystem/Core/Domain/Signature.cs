using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace JobCardSystem.Core.Domain
{
    public class Signature
    {
        [Key]
        public int Id { get; set; }
        public string Dir { get; set; }
        [Display(Name = "Please select a file to upload.")]
        [Required]
        public string FileName { get; set; }

        #region Navigational Properties

        public virtual ICollection<Customer> Customers { get; set; }
        public virtual ICollection<ApplicationUser> ApplicationUsers { get; set; }

        #endregion

    }
}