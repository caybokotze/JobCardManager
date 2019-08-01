using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Security.AccessControl;
using System.Web;
using StructureMap.TypeRules;

namespace JobCardSystem.Core.Domain
{
    public class JobCard
    {
        public JobCard()
        {
            Id = 0;
            ArrivalTime = DateTime.Now;
            DepartureTime = DateTime.Now;
            Distance = 0;
        }
        public int Id { get; set; }

        [DataType(DataType.Date)]
        public DateTime CreatedAt { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Scheduled For")]
        [Required]
        public DateTime ScheduledFor { get; set; }

        public double JobTotal { get; set; }


        public DateTime? ArrivalTime { get; set; }
        public DateTime? DepartureTime { get; set; }

        //
        [Display(Name = "Distance Traveled")]
        public int Distance { get; set; }

        [Required]
        [ForeignKey("JobStatus")]
        public int JobStatusId { get; set; }

        [Required]
        [ForeignKey("JobType")]
        public int JobTypeId { get; set; }

        #region Navigational Properties

        public virtual JobStatus JobStatus { get; set; }
        public virtual JobType JobType { get; set; }
        public virtual Customer Customer { get; set; }
        //
        public virtual ICollection<ApplicationUser> ApplicationUsers { get; set; }
        public virtual ICollection<StockItem> StockItems { get; set; }
        public virtual ICollection<Customer> Customers { get; set; }
        //public virtual ICollection<JobStatusHistory> JobStatusHistories { get; set; }

        #endregion



    }
}