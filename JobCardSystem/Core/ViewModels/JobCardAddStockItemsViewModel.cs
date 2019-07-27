using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using JobCardSystem.BusinessLogic;
using JobCardSystem.Core.Domain;

namespace JobCardSystem.Core.ViewModels
{
    public class JobCardAddStockItemsViewModel
    {
        public int Id { get; set; }

        [Display(Name = "Arrival Time")]
        [DataType(DataType.DateTime)]
        public DateTime? ArrivalTime { get; set; }

        [Display(Name = "Departure Time")]
        [DataType(DataType.DateTime)]
        public DateTime? DepartureTime { get; set; }

        [Display(Name = "Distance Traveled")]
        public int Distance { get; set; }

        public ICollection<StockItem> StockItems { get; set; }

        [Display(Name = "Add stock to the job card")]
        [Required]
        public string[] StockItemIdArray { get; set; }
        //
        //
        public ICollection<GetDisplayName> GetStockItemDisplayNames()
        {
            var customerDisplays = new List<GetDisplayName>();
            foreach (var item in StockItems)
            {
                customerDisplays.Add(
                    new GetDisplayName()
                    {
                        Id = item.Id,
                        DisplayName = item.Name + " - " + item.Cost.ToString("C")
                    });
            }
            return customerDisplays;
        }
    }
}