using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace JobCardSystem.Core.Domain
{
    public class Comment
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Message")]
        public string Message { get; set; }

        [ForeignKey("JobCard")]
        public int JobCardId { get; set; }
        public virtual JobCard JobCard { get; set; }
    }
}