using App.Domain.Core.Entities;
using App.EndPoints.Home_RepaireUI.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace App.EndPoints.Home_RepaireUI.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;

        public AccountController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Login2()
        {
            return View();
        }
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost] 
        public async Task <IActionResult> Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = new AppUser
                {
                    UserName = model.Email,
                    CreatAt= DateTime.Now,
                    IsDeleted=false,
                    IsSeller= false,
                    IsCreated=false,
                    Wallet=0,
                    Email = model.Email,
                    Address= model.Address,
                    LockoutEnabled=false,
                    AccessFailedCount=0,
                    TwoFactorEnabled=false,
                    PhoneNumberConfirmed=false,
                    
                };
                
                   var result = await _userManager.CreateAsync(user, model.Password);
                 if(result.Succeeded)
                {
                    await _signInManager.SignInAsync(user, isPersistent: false);
                    return RedirectToAction("Index","Home");
                }
                else
                {
                     foreach(var item in result.Errors)
                    {
                        ModelState.AddModelError(string.Empty , item.Description);
                    }
                }
                 
            }


            return View(model);
        }
    }
}
