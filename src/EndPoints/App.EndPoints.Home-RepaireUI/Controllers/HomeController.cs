using App.Domain.Core.AppServices.Admins;
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
        private readonly IProductAppservice _productAppservice;
        

        public HomeController(ILogger<HomeController> logger, IProductAppservice productAppservice )
        {
            _logger = logger;
            _productAppservice = productAppservice;
        }


        public IActionResult Index()
        {
            
            return View();
        }

        public async Task<IActionResult>Allproduct(CancellationToken cancellationToken)
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