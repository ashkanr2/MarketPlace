using App.Domain.Core.AppServices.Admins;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace App.EndPoints.Home_RepaireUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class UserController : Controller
    {
        //private readonly IAppUserServices _commentAppservice;
        private readonly IMapper _mapper;
        public IActionResult GetAll()
        {
            return View();
        }
    }
}
