using FinancePalika.Areas.FinanceSys.Models;
using FinancePalika.ViewModels;

namespace FinancePalika.Areas.FinanceSys.Interface
{
    public interface ISahakariSuchi
    {
        Task<List<SahakariSuchiViewModel>> GetAllSahakariSuchi();
        Task<ResponseModel> InsertSahakariSuchit(SahakariSuchiViewModel model);
        Task<SahakariSuchiViewModel> GetSahakariSuchitById(int? id);
        Task<bool> Delete(int id);
    }
}
