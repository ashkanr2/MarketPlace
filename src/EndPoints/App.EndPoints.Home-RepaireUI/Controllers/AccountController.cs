using App.Domain.Core.Entities;
using App.EndPoints.Home_RepaireUI.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Net;

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

        public async Task <IActionResult> Login()
        {
            await _signInManager.SignOutAsync();
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(model.UserName, model.Password, false,false);
                if (result.Succeeded)
                {
                    return LocalRedirect("~/");
                }
                ModelState.AddModelError(string.Empty, "خطا در لاگین ");

            }
            return View(model);
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
                    Name = model.Name,
                    LastName= model.LastName,
                    Address=model.Address,
                    Email = model.Email,
                    CreatAt = DateTime.Now,
                    IsDeleted =false,
                    IsSeller= false,
                    IsCreated=false,
                    UserName=model.Email,
                    Wallet=0,
                    
                    //LockoutEnabled=false,
                    //AccessFailedCount=0,
                    //TwoFactorEnabled=false,
                    //PhoneNumberConfirmed=false,
                    
                };
                
                   var result = await _userManager.CreateAsync(user, model.Password);
                 if(result.Succeeded)
                {
                    await _signInManager.SignInAsync(user, isPersistent: true);
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
