using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace JobCardSystem.Core.Domain
{
    public class ServiceContract
    {
        public int Id { get; set; }
        [Required]
        [Display(Name = "Services Per Month")]
        public int Services { get; set; }
    }
}