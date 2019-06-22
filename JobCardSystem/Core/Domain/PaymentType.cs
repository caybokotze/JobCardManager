using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace JobCardSystem.Core.Domain
{
    public class PaymentType
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [Display(Name = "Please enter a payment type name.")]
        public string Name { get; set; }

    }
}