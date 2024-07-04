using FinancePalika.Areas.FinanceSys.Interface;
using FinancePalika.Areas.FinanceSys.Models;
using FinancePalika.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace FinancePalika.Areas.FinanceSys.Controllers
{
    [Area("FinanceSys")]
    public class PrayogkartaController : Controller
    {
        private readonly IPrayogKarta _prayogKarta;

        public PrayogkartaController(IPrayogKarta prayogKarta)
        {
            _prayogKarta = prayogKarta;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _prayogKarta.GetAll());
        }

        public async Task<IActionResult> Create(string? id)
        {
            return PartialView(await _prayogKarta.GetById(id));
        }

        [HttpPost]
        public async Task<IActionResult> Create(PrayogKartaViewModel prayogKarta)
        {
            ResponseModel response = await _prayogKarta.Create(prayogKarta);
            if (response.Status == true)
            {
                return RedirectToAction("Index");
            }
            return PartialView();
        }

        public async Task<IActionResult> Delete(string? id)
        {
            return PartialView(await _prayogKarta.GetById(id));
        }

        [HttpPost]
        public async Task<IActionResult> DeleteConfirm(string id)
        {
            ResponseModel response = await _prayogKarta.Delete(id);
            if (response.Status == true)
            {
                return RedirectToAction("Index");
            }
            return RedirectToAction("Delete", "PrayogKarta", new { id = id });
        }
    }
}
