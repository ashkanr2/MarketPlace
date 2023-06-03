using Microsoft.AspNetCore.Mvc;

namespace App.EndPoints.Home_RepaireUI.Areas.Admin.Controllers
{
    public class AllProductController : Controller
    {
        [Area("Admin")]
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Edite()
        {
            return View();
        }
        public IActionResult Create()
        {
            return View();
        }
        public IActionResult Update()
        {
            return View();
        }

    }
}
