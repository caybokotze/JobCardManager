using System.ComponentModel.DataAnnotations;

namespace JobCardSystem.Models
{
    public class ForgotViewModel
    {
        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }
}