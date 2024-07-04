using System.ComponentModel.DataAnnotations;

namespace FinancePalika.Areas.FinanceSys.Models
{
    public class PrayogKartaViewModel
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();

        [Required]
        [EmailAddress]
        [Display(Name = "इमेल")]
        public string Email { get; set; }

        [Required]
        [Display(Name = "पुरा नाम")]
        public string FullName { get; set; }
        [Required]
        [Display(Name = "प्रयोगकर्ता नाम")]
        public string PrayogkartaName { get; set; }
        [Required]
        [Display(Name = "प्रयोगकर्ताको प्रकार")]
        public string Role { get; set; }

        [Phone]
        [Display(Name = "फोन नं")]
        public string PhoneNumber { get; set; } = null!;

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "पास्स्वोर्ड")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "पुन पास्स्वोर्ड")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }
    }
}
