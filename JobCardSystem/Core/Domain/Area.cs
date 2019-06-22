using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace JobCardSystem.Core.Domain
{
    public class Area
    {
        [Key]
        //Note: Entity framework automatically resolves Id to AreaId as a Partial Key.
        public int Id { get; set; }
        //
        [Display(Name = "Area Name")]
        public string AreaName { get; set; }
    }
}