using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using JobCardSystem.Core.Domain;

namespace JobCardSystem.Core.ViewModels
{
    public class CustomerViewModel
    {
        [Key]
        public int Id { get; set; }

        public DateTime CreatedAt { get; set; }

        [Display(Name = "Customer Name")]
        [Required]
        public string Name { get; set; }

        [Display(Name = "Customer Surname")]
        [Required]
        public string Surname { get; set; }

        [Display(Name = "Customer Address")]
        public string Address { get; set; }

        [Required(ErrorMessage = "Please enter customer email.")]
        [Display(Name = "Email Address:")]
        [EmailAddress]
        public string Email { get; set; }

        [Display(Name = "Industry")]
        public string Industry { get; set; }

        [Display(Name = "Cellphone Number")]
        [DataType(DataType.PhoneNumber)]
        [Required]
        public string CellNumber { get; set; }

        

        [Display(Name = "Services Contract")]
        [Required(ErrorMessage = "Please select a value from the drop down list.")]
        public int ServiceContractId { get; set; }
        
        [Display(Name = "Select Area")]
        [Required]
        public int AreaId { get; set; }


        #region Drop Down Lists

        public ICollection<ServiceContract> ServiceContracts { get; set; }

        #endregion

        #region Index Display

        public ServiceContract ServiceContract { get; set; }
        //
        public Area Area { get; set; }


        #endregion
    }
}