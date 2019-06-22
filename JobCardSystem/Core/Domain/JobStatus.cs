using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.AccessControl;
using System.Web;

namespace JobCardSystem.Core.Domain
{
    public class JobStatus
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [Display(Name = "Status Name")]
        public string Name { get; set; }

    }
}