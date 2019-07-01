using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using JobCardSystem.Constants;
using JobCardSystem.Core.Domain;
using Microsoft.AspNet.Identity.EntityFramework;

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

    //AssignRole View Model is used to edit a user and assign a Area as-well as a Role.
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


    public class ExternalLoginConfirmationViewModel
    {
        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }

    public class ExternalLoginListViewModel
    {
        public string ReturnUrl { get; set; }
    }

    public class SendCodeViewModel
    {
        public string SelectedProvider { get; set; }
        public ICollection<System.Web.Mvc.SelectListItem> Providers { get; set; }
        public string ReturnUrl { get; set; }
        public bool RememberMe { get; set; }
    }

    public class VerifyCodeViewModel
    {
        [Required]
        public string Provider { get; set; }

        [Required]
        [Display(Name = "Code")]
        public string Code { get; set; }
        public string ReturnUrl { get; set; }

        [Display(Name = "Remember this browser?")]
        public bool RememberBrowser { get; set; }

        public bool RememberMe { get; set; }
    }

    public class ForgotViewModel
    {
        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }

    public class LoginViewModel
    {
        [Required]
        [Display(Name = "Email")]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [Display(Name = "Remember me?")]
        public bool RememberMe { get; set; }
    }

    

    public class ResetPasswordViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }

        public string Code { get; set; }
    }

    public class ForgotPasswordViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }
}
