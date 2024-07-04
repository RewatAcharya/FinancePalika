using FinancePalika.Models;
using FinancePalika.Models.financeAdmin;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace FinancePalika.Services
{
    public class AppDbContext : IdentityDbContext<ApplicationUser>
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
            
        }

        public DbSet<State> State { get; set; }
        public DbSet<District> District { get; set; }
        public DbSet<SahakariSuchi> SahakariSuchi { get; set; }
    }
}
