using App.Domain.Core.DataAccess;
using App.Domain.Core.DtoModels;
using App.EndPoints.Home_RepaireUI.Config;
using App.EndPoints.Home_RepaireUI.Models;
using App.Infrastructures.Data.Repositories.DataAccess.Ripository;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace App.EndPoints.Home_RepaireUI.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        //private readonly AppSettings _appSettings;


        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
           
        }

        //public HomeController(ILogger<HomeController> logger, AppSettings appSettings)
        //{
        //    _logger = logger;
        //    _appSettings = appSettings;
        //}

        //public IActionResult Index(int id)
        //{
        //    if (ControllerContext.ActionDescriptor.ControllerName == _appSettings.AllowedController &&
        //    ControllerContext.ActionDescriptor.ActionName == _appSettings.AllowedAction &&
        //    id == _appSettings.AllowedValue)
        //    {
        //        return View();
        //    }
        //    else
        //    {
        //        return RedirectToAction("Index", "Privacy");
        //    }



        //    return View();
        //}
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        
    }
}