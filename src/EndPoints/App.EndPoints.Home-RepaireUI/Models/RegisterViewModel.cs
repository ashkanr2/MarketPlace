using System.ComponentModel.DataAnnotations;

namespace App.EndPoints.Home_RepaireUI.Models
{
    public class RegisterViewModel
    {
        [Required]
        [Display(Name ="ایمیل")]
        [EmailAddress]
        public string Email { get; set; }


        [Required]
        [StringLength(10,ErrorMessage = "تعداد اشتباه است ")]
        [DataType(DataType.Password)]  
        public string Password { get; set; }

        [Required]
        [StringLength(10, ErrorMessage = "تعداد اشتباه است ")]
        [Compare(nameof(Password), ErrorMessage = " رمز عبور ها یکسان نیست")]
        public string ConfirmPassword { get; set; }

        public string Address { get; set; }
    }
}
 