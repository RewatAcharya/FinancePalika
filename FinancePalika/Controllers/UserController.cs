using Microsoft.AspNetCore.Mvc;

namespace FinancePalika.Controllers
{
    public class UserController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
