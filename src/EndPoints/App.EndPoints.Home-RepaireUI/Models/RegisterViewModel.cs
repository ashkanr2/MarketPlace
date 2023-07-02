using System.ComponentModel.DataAnnotations;

namespace App.EndPoints.Home_RepaireUI.Models
{
    public class RegisterViewModel
    {
        [Required]
        [Display(Name = "نام")]
        public string Name { get; set; }

        [Required]
        [Display(Name = "نام خانوادگی")]
        public string LastName { get; set; }

        [Required]
        [Display(Name = "ایمیل")]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [Display(Name = "رمزعبور")]
        public string Password { get; set; }

        [Required]
        [Compare(nameof(Password), ErrorMessage = " رمز عبور ها یکسان نیست")]
        public string ConfirmPassword { get; set; }

        [Required]
        [Display(Name = "نشانی")]
        public string Address { get; set; }

        [Display(Name = "تصویر")]
        public IFormFile Image { get; set; }
    }

}
