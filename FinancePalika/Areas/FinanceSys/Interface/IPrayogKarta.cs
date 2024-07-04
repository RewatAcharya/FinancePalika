using FinancePalika.Areas.FinanceSys.Models;
using FinancePalika.Models;
using FinancePalika.ViewModels;

namespace FinancePalika.Areas.FinanceSys.Interface
{
    public interface IPrayogKarta
    {
        Task<List<PrayogKartaViewModel>> GetAll(); 
        Task<PrayogKartaViewModel> GetById(string id);
        Task<ResponseModel> Create(PrayogKartaViewModel prayogKarta);
        Task<ResponseModel> Delete(string id);
    }
}
