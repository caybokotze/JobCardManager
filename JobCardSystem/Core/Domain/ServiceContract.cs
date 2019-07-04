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
        [Display(Name = "Services Contract")]
        public string ServiceName { get; set; }

        [Required]
        [Display(Name = "Months Per Year")]
        public int Months { get; set; }
    }
}