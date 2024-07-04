using FinancePalika.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using FinancePalika.Models;
using FinancePalika.Areas.FinanceSys.Interface;
using FinancePalika.Areas.FinanceSys.Repository;
using FinancePalika.Utilities;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<AppDbContext>(options =>
   {
       var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
       options.UseSqlServer(connectionString);
   });

builder.Services.AddDefaultIdentity<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = false)
    .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<AppDbContext>();

//services scoped
builder.Services.AddScoped<IUtility, Utility>();
builder.Services.AddScoped<IPrayogKarta, PrayogKartaRepository>();
builder.Services.AddScoped<ISahakariSuchi, SahakariSuchiRepository>();

builder.Services.AddRazorPages();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();
#pragma warning disable ASP0014 // Suggest using top level route registrations
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
      name: "areas",
      pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
    );

    app.MapControllerRoute(
    name: "default",
    pattern: "{controller=LandingPage}/{action=Index}/{id?}");
});
#pragma warning restore ASP0014 // Suggest using top level route registrations

app.MapRazorPages();

using (var scope = app.Services.CreateScope())
{
    var userManager = scope.ServiceProvider.GetService(typeof(UserManager<ApplicationUser>))
        as UserManager<ApplicationUser>;
    var roleManager = scope.ServiceProvider.GetService(typeof(RoleManager<IdentityRole>))
        as RoleManager<IdentityRole>;

    await DbInitializer.SeedDataAsync(userManager, roleManager);
}

app.Run();
