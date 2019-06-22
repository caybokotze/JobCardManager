using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.AccessControl;
using System.Web;

namespace JobCardSystem.Core.Domain
{
    public class JobCard
    {
        public int Id { get; set; }

        [DataType(DataType.Date)]
        public DateTime CreatedAt { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Scheduled For")]
        [Required]
        public DateTime ScheduledFor { get; set; }

        public double JobTotal { get; set; }

        [Display(Name = "Site Location")]
        [Required]
        public string SiteLocation { get; set; }

        public DateTime? ArrivalTime { get; set; }
        public DateTime? DepartureTime { get; set; }

        [Display(Name = "Distance Traveled")]
        public int Distance { get; set; }

        public int JobStatusId { get; set; }
        public int JobTypeId { get; set; }

        #region Navigational Properties

        public virtual JobStatus JobStatus { get; set; }
        public virtual JobType JobType { get; set; }

        public virtual ICollection<ApplicationUser> ApplicationUsers { get; set; }
        public virtual ICollection<Customer> Customers { get; set; }

        #endregion



    }
}