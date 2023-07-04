using App.Domain.Core.AppServices.Admins;
using App.Domain.Core.DataAccess;
using App.Domain.Core.DtoModels;
using App.Domain.Core.Entities;
using App.EndPoints.Home_RepaireUI.Config;
using App.EndPoints.Home_RepaireUI.Models;
using App.Frameworks.Web;
using App.Infrastructures.Data.Repositories.DataAccess.Ripository;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace App.EndPoints.Home_RepaireUI.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IProductAppservice _productAppservice;
        private readonly IAppUserRipositry _appuserRipositry;
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly DateConvertor _dateConvertor;
        public HomeController(ILogger<HomeController> logger, IProductAppservice productAppservice, IAppUserRipositry appuserRipositry, UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, DateConvertor dateConvertor)
        {
            _logger = logger;
            _productAppservice = productAppservice;
            _appuserRipositry = appuserRipositry;
            _userManager = userManager;
            _signInManager = signInManager;
            _dateConvertor = dateConvertor;
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
        [HttpGet]
        public async Task<IActionResult> Profile(CancellationToken cancellationToken)
        {
            if (!(_signInManager.IsSignedIn(User)))
            {
                TempData["Message"] = "لطفا وارد حساب کاربری شوید";
                return RedirectToAction("Index", "Home");
            }

            int userId = (await _userManager.GetUserAsync(User)).Id;
            var userInfo = await _appuserRipositry.GetDetail(userId, cancellationToken);
            return View(userInfo);
        }
        public IActionResult Hello()
        {
            return View();
        }
    }
}