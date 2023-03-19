using Microsoft.AspNetCore.Mvc;

namespace YemekKitabı.Controllers
{
    public class CookController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
