using FinancePalika.Areas.FinanceSys.Interface;
using FinancePalika.Areas.FinanceSys.Models;
using FinancePalika.Models;
using FinancePalika.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages.Manage;

namespace FinancePalika.Areas.FinanceSys.Repository
{
    public class PrayogKartaRepository : IPrayogKarta
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public PrayogKartaRepository(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<ResponseModel> Create(PrayogKartaViewModel prayogKarta)
        {
            ResponseModel responseModel = new();

            if (prayogKarta.Id != null)
            {
                var existingUser = await _userManager.FindByIdAsync(prayogKarta.Id);

                if (existingUser != null)
                {
                    existingUser.FullName = prayogKarta.FullName;
                    existingUser.PhoneNumber = prayogKarta.PhoneNumber;
                    existingUser.Email = prayogKarta.Email;
                    existingUser.PrayogkartaName = prayogKarta.PrayogkartaName;

                    var updateResult = await _userManager.UpdateAsync(existingUser);

                    if (updateResult.Succeeded)
                    {
                        // Remove existing roles and add the new role
                        var existingRoles = await _userManager.GetRolesAsync(existingUser);
                        await _userManager.RemoveFromRolesAsync(existingUser, existingRoles);
                        await _userManager.AddToRoleAsync(existingUser, prayogKarta.Role);

                        responseModel.Status = true;
                        return responseModel;
                    }
                    else
                    {
                        responseModel.Status = false;
                    }
                }
            }
            else
            {
                var newUser = new ApplicationUser
                {
                    FullName = prayogKarta.FullName,
                    PrayogkartaName = prayogKarta.PrayogkartaName,
                    Email = prayogKarta.Email,
                    PhoneNumber = prayogKarta.PhoneNumber,
                    UserName = prayogKarta.Email.ToUpper(),
                };

                var createResult = await _userManager.CreateAsync(newUser, prayogKarta.Password);

                if (createResult.Succeeded)
                {
                    await _userManager.AddToRoleAsync(newUser, prayogKarta.Role);

                    responseModel.Status = true;
                    return responseModel;
                }
                else
                {
                    responseModel.Status = false;
                }
            }

            return responseModel;
        }


        public async Task<ResponseModel> Delete(string id)
        {
            ResponseModel responseModel = new();
            var user = await _userManager.FindByIdAsync(id);
            if (user != null)
            {
                var result = await _userManager.DeleteAsync(user);
                if (result.Succeeded)
                {
                    responseModel.Status = true;
                    return responseModel;
                }
            }
            responseModel.Status = false;
            return responseModel;
        }

        public async Task<List<PrayogKartaViewModel>> GetAll()
        {
            var users = await _userManager.Users.ToListAsync();
            List<PrayogKartaViewModel> kartas = new();

            foreach (var item in users)
            {
                var roles = await _userManager.GetRolesAsync(item);

                var karta = new PrayogKartaViewModel
                {
                    Id = item.Id,
                    FullName = item.FullName,
                    PrayogkartaName = item.PrayogkartaName,
                    Email = item.Email,
                    PhoneNumber = item.PhoneNumber,
                    Role = roles.FirstOrDefault()
                };
                kartas.Add(karta);
            }
            return kartas;
        }

        public async Task<PrayogKartaViewModel> GetById(string id)
        {
            var users = await _userManager.FindByIdAsync(id);
            if (users != null)
            {
                var roles = await _userManager.GetRolesAsync(users);
                PrayogKartaViewModel prayogKarta = new()
                {
                    Id = users.Id,
                    FullName = users.FullName,
                    PrayogkartaName = users.PrayogkartaName,
                    Email = users.Email,
                    PhoneNumber = users.PhoneNumber,
                    Role = roles.FirstOrDefault()

                };
                return prayogKarta;
            }
            return null;
        }
    }
}
