using FinancePalika.Models;
using Microsoft.AspNetCore.Identity;

namespace FinancePalika.Services
{
    public class DbInitializer
    {
        public static async Task SeedDataAsync(UserManager<ApplicationUser>? userManager,
            RoleManager<IdentityRole>? roleManager)
        {
            if (userManager == null || roleManager == null)
            {
                return;
            }

            //create roles
            var existsAdmin = await roleManager.RoleExistsAsync("Admin");
            if (!existsAdmin)
            {
                await roleManager.CreateAsync(new IdentityRole("Admin"));
            }
            var existsUser = await roleManager.RoleExistsAsync("User");
            if (!existsUser)
            {
                await roleManager.CreateAsync(new IdentityRole("User"));
            }

            //create an admin
            var adminUsers = await userManager.GetUsersInRoleAsync("Admin");
            if (!adminUsers.Any())
            {
                var user = new ApplicationUser
                {
                    FullName = "Softech Admin",
                    PrayogkartaName = "Softech Foundation",
                    Email = "softech@gmail.com",
                    UserName = "softech@gmail.com"
                };

                string defaultPass = "Softech@123";
                var result = await userManager.CreateAsync(user, defaultPass);
                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(user, "Admin");
                }
            }
        }
    }
}
