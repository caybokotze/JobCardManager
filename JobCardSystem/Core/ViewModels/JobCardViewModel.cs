using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using JobCardSystem.BusinessLogic;
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

        [Display(Name = "Arrival Time")]
        [DataType(DataType.Time)]
        public DateTime? ArrivalTime { get; set; }

        [Display(Name = "Departure Time")]
        [DataType(DataType.Time)]
        public DateTime? DepartureTime { get; set; }

        [Display(Name = "Distance Traveled")]
        public int Distance { get; set; }

        #region Drop Down Lists.

        [Required]
        [Display(Name = "Job Type")]
        public int JobTypeId { get; set; } = 1;
        //Drop Down List
        public ICollection<JobType> JobTypes { get; set; }

        [Required]
        [Display(Name = "Job Status")]
        public int JobStatusId { get; set; }
        //Drop Down List
        public ICollection<JobStatus> JobStatuses { get; set; }

        //[NotMapped]
        //[Display(Name = "Select Customers")]
        //[Required]
        //public int[] SelectedCustomerIdArray { get; set; }

        [Display(Name = "Select Customer")]
        [Required]
        public int CustomerId { get; set; }

        public Customer Customer { get; set; }

        public ICollection<Customer> Customers { get; set; }

        [Display(Name = "Add Staff To Job Card")]
        [Required]
        public string[] ApplicationUserIdArray { get; set; }
        //s
        public ICollection<ApplicationUser> Staff { get; set; }

        [Display(Name = "Select Stock")]
        [Required]
        public int StockItemId { get; set; }
        //
        public ICollection<StockItem> StockItems { get; set; }

        //

        public ICollection<GetDisplayName> GetCustomerDisplayNames()
        {
            var customerDisplays = new List<GetDisplayName>();
            foreach (var item in Customers)
            {
                customerDisplays.Add(
                    new GetDisplayName()
                    {
                        Id = item.Id,
                        DisplayName = item.Name + " - " + item.CellNumber
                    });
            }

            return customerDisplays;
        }

        public ICollection<GetIdentityDisplayName> GetStaffDisplayNames()
        {
            var staffDisplays = new List<GetIdentityDisplayName>();
            foreach (var item in Staff)
            {
                staffDisplays.Add(
                    new GetIdentityDisplayName()
                    {
                        Id = item.Id,
                        DisplayName = item.Name + " - " + item.PhoneNumber
                    });
            }

            return staffDisplays;
        }



        #endregion
    }

    
}