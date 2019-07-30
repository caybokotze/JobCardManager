using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace JobCardSystem.Core.Domain
{
    public class ApplicationUserSignature
    {
        public int Id { get; set; }

        [Display(Name = "Image")]
        public string FileDir { get; set; }

        [Display(Name = "Application User")]
        public string ApplicationUserId { get; set; }

        public virtual ApplicationUser ApplicationUser { get; set; }

        [NotMapped]
        public string GetDisplayName => ApplicationUser.Name + " " + ApplicationUser.Surname;

    }
}