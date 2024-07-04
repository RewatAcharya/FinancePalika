using FinancePalika.Areas.FinanceSys.Interface;
using FinancePalika.Areas.FinanceSys.Models;
using FinancePalika.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace FinancePalika.Areas.FinanceSys.Controllers
{
    [Area("FinanceSys")]
    public class SahakariSuchiController : Controller
    {
        private readonly ISahakariSuchi _sahakariSuchi = null;
        public SahakariSuchiController(ISahakariSuchi SahakariSuchiRepository)
        {
            _sahakariSuchi = SahakariSuchiRepository;
        }
        public async Task<IActionResult> Index()
        {
            return View(await _sahakariSuchi.GetAllSahakariSuchi());
        }
        public async Task<IActionResult> Create(int id = 0)
        {
            return PartialView(await _sahakariSuchi.GetSahakariSuchitById(id));
        }
        [HttpPost]
        public async Task<IActionResult> Create(SahakariSuchiViewModel model)
        {
            if (ModelState.IsValid)
            {
                var response = await _sahakariSuchi.InsertSahakariSuchit(model);
                if (response.Status)
                {
                    TempData["trackingNo"] = JsonConvert.SerializeObject(response);
                    return RedirectToAction("Index");
                }
            }
            return PartialView(model);
        }
        public async Task<IActionResult> Details(int id)
        {
            return View(await _sahakariSuchi.GetSahakariSuchitById(id));
        }

        public async Task<IActionResult> Delete(int id)
        {
            return PartialView(await _sahakariSuchi.GetSahakariSuchitById(id));
        }

        [HttpPost]
        public async Task<IActionResult> DeleteConfirm(int id)
        {
            bool response = await _sahakariSuchi.Delete(id);
            if (response == true)
            {
                return RedirectToAction("Index");
            }
            return RedirectToAction("Delete", "SahakariSuchi", new { id = id });
        }
    }
}

