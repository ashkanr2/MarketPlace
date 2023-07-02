using App.Domain.Core.AppServices.Admin;
using App.Domain.Core.DataAccess;
using App.Domain.Core.Entities;
using App.EndPoints.Home_RepaireUI.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.IO;

namespace App.EndPoints.Home_RepaireUI.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly IAppUserRipositry _appUserRipositry;
        private readonly IWebHostEnvironment _hostingEnvironment;
        private readonly IImageAppservice _imageAppservice;
        public AccountController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, IAppUserRipositry appUserRipositry, IWebHostEnvironment hostingEnvironment, IImageAppservice imageAppservice)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _appUserRipositry = appUserRipositry;
            _hostingEnvironment = hostingEnvironment;
            _imageAppservice = imageAppservice;
        }

        public async Task <IActionResult> Login()
        {
            await _signInManager.SignOutAsync();
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model,CancellationToken cancellationToken)
        {
            if (ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(model.UserName, model.Password, false, false);
                
                if (result.Succeeded)
                {
                  
                    var user = await _userManager.FindByNameAsync(model.UserName);
                    var roles = _appUserRipositry.GetRoles(user.Id, cancellationToken);
                    foreach (var item in roles.Result)
                    {
                        //if(item == "Admin")
                        //{
                        //    return RedirectToAction("Index", "Home", new { area = "Admin" });
                        //}
                        //if(item == "Customer")
                        //{
                        //    return RedirectToAction("Index", "Home", new { area = "Admin" });
                        //}
                        if (item == "Seller")
                        {
                            return RedirectToAction("Index", "Home", new { area = "Seller" });
                        }

                    }
                  
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
        public async Task<IActionResult> Register(RegisterViewModel model, CancellationToken cancellationToken)
        {
            if (ModelState.IsValid)
            {
                // Check if an image was uploaded
                if (model.Image != null && model.Image.Length > 0)
                {
                    // Generate a unique file name using a combination of timestamp and the original file name
                    var fileNameWithoutExtension = DateTime.Now.Ticks + "_+_" + Path.GetFileName(model.Image.FileName);

                    // Get the path to the wwwroot folder
                    var wwwrootPath = _hostingEnvironment.WebRootPath;

                    // Combine the wwwroot path with the desired image upload directory
                    var uploadPath = Path.Combine(wwwrootPath, "uploads");

                    // Create the uploads directory if it doesn't exist
                    if (!Directory.Exists(uploadPath))
                    {
                        Directory.CreateDirectory(uploadPath);
                    }

                    // Combine the upload path with the file name and the desired file extension
                    var fileName = fileNameWithoutExtension + Path.GetExtension(model.Image.FileName);

                    // Combine the upload path with the file name to get the full file path
                    var filePath = Path.Combine(uploadPath, fileName);

                    // Save the uploaded image to the file system
                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        await model.Image.CopyToAsync(stream);
                    }

                    var user = new AppUser
                    {
                        UserProfileImageId = (await _imageAppservice.Upload(fileNameWithoutExtension, true, cancellationToken)),
                        Name = model.Name,
                        LastName = model.LastName,
                        Email = model.Email,
                        UserName = model.Email,
                        Address = model.Address,

                    };
                    var result = await _userManager.CreateAsync(user, model.Password);
                }


            }

            return View(model);
        }

    }
}
