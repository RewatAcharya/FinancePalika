using Microsoft.AspNetCore.Identity;

namespace FinancePalika.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string FullName { get; set; }
        public string PrayogkartaName { get; set; }
    }
}
