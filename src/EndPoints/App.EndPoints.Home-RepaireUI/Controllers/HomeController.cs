using App.Domain.Core.DataAccess;
using App.Domain.Core.DtoModels;
using App.EndPoints.Home_RepaireUI.Models;
using App.Infrastructures.Data.Repositories.DataAccess.Ripository;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace App.EndPoints.Home_RepaireUI.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
 
        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
           
        }


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
        //public async Task<IActionResult> SignUp([FromBody]AppUserDto userDto)
        //{
        //    var result = await _appUserRipository.SignUpAsync(userDto);
        //    if(result.Succeeded)
        //    {
        //        return Ok(result.Succeeded);
        //    }
        //    return Unauthorized();
        //}
    }
}