using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using JobCardSystem.BusinessLogic;
using JobCardSystem.Core.Domain;

namespace JobCardSystem.Core.ViewModels
{
    public class StockItemViewModel
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Supplier Name")]
        public string Name { get; set; }

        [Display(Name = "Description")]
        public string Description { get; set; }

        [Required]
        [Display(Name = "Available Units")]
        public int QuantityAvailable { get; set; }

        [Required]
        [Display(Name = "Purchasing Cost")]
        public double Cost { get; set; }

        [Required]
        [Display(Name = "Selling Cost")]
        public double SellingPrice { get; set; }
        //
        public ICollection<Supplier> Suppliers { get; set; }

        public ICollection<GetDisplayName> GetDisplayNames()
        {
            var supplierDisplayNames = new List<GetDisplayName>();
            foreach (var item in Suppliers)
            {
                supplierDisplayNames.Add(
                    new GetDisplayName()
                    {
                        Id = item.Id,
                        DisplayName = item.Name + " - " + item.ContactNumber
                    });
            }

            return supplierDisplayNames;
        }
    }
}