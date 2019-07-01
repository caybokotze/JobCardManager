
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Security.Claims;
using System.Threading.Tasks;
using JobCardSystem.Constants;
using Microsoft.Ajax.Utilities;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace JobCardSystem.Core.Domain
{
    public class CustomRole : IdentityRole
    {
        public CustomRole()
        {
            
        }
    }

    public class RandomUserRole : IdentityUserRole
    {
        public RandomUserRole()
        {
            
        }
    }

    public class ApplicationUserClaims : IdentityUserClaim
    {
        public ApplicationUserClaims()
        {
            
        }
    }

    public class ApplicationUser : IdentityUser
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }

        public ApplicationUser()
        {
            
        }

        [Required(ErrorMessage = "Please enter a name for the user.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Please enter a surname for the user.")]
        public string Surname { get; set; }

        [Required]
        [Display(Name = "Email Address")]
        [DataType(DataType.EmailAddress)]
        public override string Email { get; set; }

        [Required]
        [Display(Name = "Phone Number")]
        [StringLength(11, ErrorMessage = "Phone number can not be longer than 11 digits.")]
        public override string PhoneNumber { get; set; }

        [Required]
        [Display(Name = "Full ID Number")]
        [StringLength(MaxConstants.IdNumber, ErrorMessage = "Id Number can not be longer than digits.")]
        public string IdNumber { get; set; }

        [Required]
        [Display(Name = "Select Area")]
        public int AreaId { get; set; }

        #region Navigational Properties
        public virtual Area Area { get; set; }
        public virtual ICollection<JobCard> JobCards { get; set; }
        public virtual ICollection<Signature> Signatures { get; set; }
        public virtual ICollection<PurchaseOrder> PurchaseOrders { get; set; }

        #endregion

    }
}