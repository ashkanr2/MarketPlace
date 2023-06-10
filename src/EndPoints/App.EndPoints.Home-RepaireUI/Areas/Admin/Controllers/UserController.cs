using App.Domain.Core.AppServices.Admins;
using App.Domain.Core.DataAccess;
using App.Domain.Core.DtoModels;
using App.Domain.Core.Entities;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
using App.EndPoints.Home_RepaireUI.Areas.Admin.Models.Comment;
using App.EndPoints.Home_RepaireUI.Areas.Admin.Models.User;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace App.EndPoints.Home_RepaireUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class UserController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IAppUserRipositry _IAppUserRipositry;
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
      

        public UserController(IAppUserRipositry iAppUserRipositry, IMapper mapper, UserManager<AppUser> userManager, SignInManager<AppUser> signInManager)
        {
            _IAppUserRipositry = iAppUserRipositry;
            _mapper = mapper;
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public async Task<IActionResult> GetAllUsers( CancellationToken cancellation)
        {

            var users = await _IAppUserRipositry.GetAll(cancellation);
            var userViewModels = users.Select(user => new AppUserViewModel
            {
                Id = user.Id,
                Address = user.Address,
                CreatAt = user.CreatAt,
                IsCreated = user.IsCreated,
                IsSeller = user.IsSeller,
                Name= user.Name,
                LastName= user.LastName,
                


                UserProfileImageId = user.UserProfileImageId,

                // add other properties as necessary
            }).ToList();
            return View(userViewModels);
        }
        public async Task<IActionResult>Active(int Id,CancellationToken cancellation)
        {
            var user = await _IAppUserRipositry.GetDetail(Id, cancellation);
            user.IsCreated = true;
            await _IAppUserRipositry.Update(user, cancellation);
            return RedirectToAction("GetAllUsers");
        }
        public async Task<IActionResult> DiActivated(int Id, CancellationToken cancellation)
        {
            var user = await _IAppUserRipositry.GetDetail(Id, cancellation);
            user.IsCreated = false;
            await _IAppUserRipositry.Update(user, cancellation);
            return RedirectToAction("GetAllUsers");
        }
        [HttpGet]
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
        [HttpGet]
        public async Task<IActionResult> EditeUserInformation(int Id, CancellationToken cancellation)
        {   var d = (await _IAppUserRipositry.GetDetail(Id, cancellation));
            var user =_mapper.Map<AppUser>(await _IAppUserRipositry.GetDetail(Id, cancellation));
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
        public async Task<IActionResult> EditeInformation(AppUserViewModel user , CancellationToken CancellationToken)
        {
            
            var appuser = new AppUserDto
            {
                Id = user.Id,
                Name = user.Name,
                LastName = user.LastName,
                Address= user.Address,
            };
            await _IAppUserRipositry.Update(appuser, CancellationToken);
            return RedirectToAction("Index", "Home");
        }

    }
}
