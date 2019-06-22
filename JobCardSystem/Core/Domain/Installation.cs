using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace JobCardSystem.Core.Domain
{
    public class Installation
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Location is a required field.")]
        [Display(Name = "Place")]
        public string Location { get; set; }

        [Display(Name = "Date:")]
        [DataType(DataType.Date)]
        public DateTime? Date { get; set; }

        public int CustomerId { get; set; }

        #region Navigational Properties

        public virtual Customer Customer { get; set; }
        public virtual Invoice Invoice { get; set; }

        #endregion


    }
}