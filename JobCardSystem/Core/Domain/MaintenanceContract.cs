using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace JobCardSystem.Core.Domain
{
    public class MaintenanceContract
    {
        public int Id { get; set; }

        [Display(Name = "Maintenance Contract")]
        [Required]
        public string Name { get; set; }
    }
}