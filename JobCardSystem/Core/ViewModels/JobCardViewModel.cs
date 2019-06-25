using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using JobCardSystem.Core.Domain;

namespace JobCardSystem.Core.ViewModels
{
    public class JobCardViewModel
    {
        public JobCardViewModel()
        {
            Id = 0;
        }

        public JobCardViewModel(JobCard jobCard)
        {
            Id = jobCard.Id;
            SiteLocation = jobCard.SiteLocation;
            Distance = jobCard.Distance;
            ArrivalTime = jobCard.ArrivalTime;
            DepartureTime = jobCard.DepartureTime;
            JobStatusId = jobCard.JobStatusId;
            JobTypeId = jobCard.JobTypeId;
        }

        public int Id { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Scheduled For")]
        [Required]
        public DateTime ScheduledFor { get; set; }


        [Display(Name = "Site Location")]
        [Required]
        public string SiteLocation { get; set; }

        public DateTime? ArrivalTime { get; set; }
        public DateTime? DepartureTime { get; set; }

        [Display(Name = "Distance Traveled")]
        public int Distance { get; set; }

        [Required]
        [Display(Name = "Job Status")]
        public int JobStatusId { get; set; }

        [Required]
        [Display(Name = "Job Type")]
        public int JobTypeId { get; set; }

        public ICollection<JobStatus> JobStatuses { get; set; }
        public ICollection<JobType> JobTypes { get; set; }
    }
}