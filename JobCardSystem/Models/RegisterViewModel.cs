using System.ComponentModel.DataAnnotations;
using JobCardSystem.Constants;
using JobCardSystem.Core.Domain;

namespace JobCardSystem.Models
{
    public class RegisterViewModel
    {
        public RegisterViewModel(ApplicationUser applicationUser)
        {
            Name = applicationUser.Name;
            Surname = applicationUser.Surname;
            PhoneNumber = applicationUser.PhoneNumber;
            IdNumber = applicationUser.IdNumber;
            Email = applicationUser.Email;
            Password = applicationUser.PasswordHash;
        }

        public RegisterViewModel()
        {
        }

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
        [StringLength(MaxConstants.IdNumber, ErrorMessage = "Id Number can not be longer than digits.")]
        public string IdNumber { get; set; }

        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The password must be at least {0} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }

    }
}