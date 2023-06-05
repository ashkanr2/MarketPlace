using System.ComponentModel.DataAnnotations;

namespace App.EndPoints.Home_RepaireUI.Models
{
    public class RegisterViewModel
    {
        [Required]
        [Display(Name = "نام")]
        public string UserName { get; set; }
        [Required]
        [Display(Name = "نام خانوادگی")]
        public string LastName { get; set; }
        [Required]
        [Display(Name = "ایمیل")]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }
  
       
        [Required]
        [Compare(nameof(Password), ErrorMessage = " رمز عبور ها یکسان نیست")]
        public string ConfirmPassword { get; set; }

        [Required]
        public string Address { get; set; }
    }
}
 