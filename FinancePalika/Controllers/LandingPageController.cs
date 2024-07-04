using Microsoft.AspNetCore.Mvc;

namespace FinancePalika.Controllers
{
    public class LandingPageController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
