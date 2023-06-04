using System.ComponentModel.DataAnnotations;

namespace App.EndPoints.Home_RepaireUI.Models
{
    public class LoginViewModel
    {
        [Required]
        [Display(Name = "ایمیل")]
        [EmailAddress]
        public string UserName { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
