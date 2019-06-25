using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using JobCardSystem.Core.Domain;

namespace JobCardSystem.Core.ViewModels
{
    public class CustomerViewModel
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Customer Name")]
        public string Name { get; set; }
        [Display(Name = "Customer Address")]
        public string Address { get; set; }
        [Required(ErrorMessage = "Please enter customer email.")]
        [Display(Name = "Email Address:")]
        [EmailAddress]
        public string Email { get; set; }

        [Display(Name = "Industry")]
        public string Industry { get; set; }

        [Display(Name = "Cellphone Number")]
        [StringLength(11)]
        public string CellNumber { get; set; }

        [Required(ErrorMessage = "Please select a contract from the drop down list.")]
        [Display(Name = "Maintenance Contract")]
        public int MaintenanceContractId { get; set; }
        

        [Display(Name = "Contract Duration")]
        [Required(ErrorMessage = "Please select a value from the drop down list.")]
        public int ContractDurationId { get; set; }
        

        [Display(Name = "Services Per Month")]
        [Required(ErrorMessage = "Please select a value from the drop down list.")]
        public int ServicesId { get; set; }
        

        #region Drop Down Lists

        public ICollection<MaintenanceContract> MaintenanceContracts { get; set; }
        public ICollection<ContractDuration> ContractDurations { get; set; }
        public ICollection<ServiceContract> ServiceContracts { get; set; }
        
        #endregion
    }
}