using Microsoft.AspNetCore.Mvc.Rendering;

namespace FinancePalika.Utilities
{
    public interface IUtility
    {
        Task<SelectList> GetStateSelectListItems();
        Task<SelectList> GetDistrictSelectListItems();
    }
}
