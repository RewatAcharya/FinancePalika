using FinancePalika.Models;
using FinancePalika.Services;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
namespace FinancePalika.Utilities
{
    public class Utility : IUtility
    {
        private readonly AppDbContext _context;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public Utility(AppDbContext context, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;

        }
        public async Task<SelectList> GetStateSelectListItems()
        {
            return new SelectList(await _context.State.ToListAsync(), nameof(State.StateId), nameof(State.StateName_Nep));
        }

        public async Task<SelectList> GetDistrictSelectListItems()
        {
            return new SelectList(await _context.District.ToListAsync(), "DistrictId", "DistrictName_Nep");
        }  
    }
}
