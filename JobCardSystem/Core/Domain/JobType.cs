using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.AccessControl;
using System.Web;

namespace JobCardSystem.Core.Domain
{
    public class JobType
    {
        public int Id { get; set; }

        [Display(Name = "Job Type Name")]
        public string Name { get; set; }
    }
}