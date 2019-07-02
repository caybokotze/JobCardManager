using System.ComponentModel.DataAnnotations;
using JobCardSystem.Constants;
using JobCardSystem.Core.Domain;

namespace JobCardSystem.Models
{
    //Account view model is used to display the list of users registered.
    public class AccountViewModel
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
        [Display(Name = "Area")]
        public int AreaId { get; set; }
        public Area Area { get; set; }

        [Display(Name = "Role")]
        public string RoleName { get; set; }

        #endregion
    }

    //Register View Model is used when a user registers for the first time.

    //AssignRole View Model is used to edit a user and assign a Area as-well as a Role.
}
