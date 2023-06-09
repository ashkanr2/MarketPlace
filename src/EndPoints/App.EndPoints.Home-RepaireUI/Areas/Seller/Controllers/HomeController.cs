using Microsoft.AspNetCore.Mvc;

namespace App.EndPoints.Home_RepaireUI.Areas.Seller.Controllers
{
    [Area("Seller")]
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
