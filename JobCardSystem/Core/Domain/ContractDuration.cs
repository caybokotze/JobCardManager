using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace JobCardSystem.Core.Domain
{
    public class ContractDuration
    {
        public int Id { get; set; }
        [Required]
        [Display(Name = "Duration in Months")]
        public int Duration { get; set; }
    }
}