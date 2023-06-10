using App.Domain.Core.DataAccess;
using App.Domain.Core.Entities;
using App.Domain.Core.DtoModels;
using Microsoft.AspNetCore.Identity;
using App.EndPoints.Home_RepaireUI.Areas.Seller.Models.User;
using Microsoft.AspNetCore.Mvc;

namespace App.EndPoints.Home_RepaireUI.Areas.Seller.Controllers
{
    [Area("Seller")]
    public class HomeController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly IAppUserRipositry _appUserRipositry;
        public HomeController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, IAppUserRipositry appUserRipositry)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _appUserRipositry = appUserRipositry;
        }

        public IActionResult Index()
        {
            return View();
        }
        public async Task<IActionResult> EditeInformation(CancellationToken cancellation)
        {
            var user = await _signInManager.UserManager.GetUserAsync(User);

            var userView = new AppUserViewModel
            {
                Id = user.Id,
                Name = user.Name,
                LastName = user.LastName,
                Address = user.Address,
                Email = user.Email,
                UserProfileImageId = user.UserProfileImageId,
                PhoneNumber = user.PhoneNumber,

            };
            return View(userView);
        }
        [HttpPost]
        public async Task<IActionResult> EditeInformation(AppUserViewModel user, CancellationToken CancellationToken)
        {

            var appuser = new AppUserDto
            {
                Id = user.Id,
                Name = user.Name,
                LastName = user.LastName,
                Address = user.Address,
            };
            await _appUserRipositry.Update(appuser, CancellationToken);
            return RedirectToAction("Index", "Home");
        }
    }
   
}
