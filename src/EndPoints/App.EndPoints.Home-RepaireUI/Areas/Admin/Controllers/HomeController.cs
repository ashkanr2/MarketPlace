using Microsoft.AspNetCore.Mvc;

namespace App.EndPoints.Home_RepaireUI.Areas.Admin.Controllers
{
    
    [Area("Admin")]
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
