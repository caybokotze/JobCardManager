using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using JobCardSystem.Constants;
using JobCardSystem.Core.Domain;
using Microsoft.AspNet.Identity.EntityFramework;

namespace JobCardSystem.Models
{
    public class EditUserViewModel
    {
        public string Id { get; set; }

        [Required(ErrorMessage = "Please enter a name for the user.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Please enter a surname for the user.")]
        public string Surname { get; set; }

        [Required]
        [Display(Name = "Phone Number")]
        [StringLength(11, ErrorMessage = "Phone number can not be longer than 11 digits.")]
        public string PhoneNumber { get; set; }

        [Required]
        [Display(Name = "Full ID Number")]
        [StringLength(MaxConstants.IdNumber, ErrorMessage = "Id Number can not be longer than 14 digits.")]
        public string IdNumber { get; set; }

        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        #region Drop Down List

        [Required]
        [Display(Name = "Select Area")]
        public int AreaId { get; set; }
        public ICollection<Area> Areas { get; set; }

        [Display(Name = "Select Role")]
        public string RoleId { get; set; }
        public ICollection<IdentityRole> Roles { get; set; }

        #endregion
    }
}