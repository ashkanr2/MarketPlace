using App.Domain.Core.AppServices.Admins;
using App.Domain.Core.DataAccess;
using App.EndPoints.Home_RepaireUI.Areas.Admin.Models.Comment;
using App.EndPoints.Home_RepaireUI.Areas.Admin.Models.User;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace App.EndPoints.Home_RepaireUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class UserController : Controller
    {
        private readonly IAppUserRipositry _IAppUserRipositry;
        private readonly IMapper _mapper;

        public UserController(IAppUserRipositry iAppUserRipositry, IMapper mapper)
        {
            _IAppUserRipositry = iAppUserRipositry;
            _mapper = mapper;
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
             
                UserProfileImageId = user.UserProfileImageId,

                // add other properties as necessary
            }).ToList();

            return View(userViewModels);
        }
    }
}
