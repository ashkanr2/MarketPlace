using App.Domain.Core.AppServices.Admins;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using App.Domain.Core.Entities;
using App.Domain.Core.DtoModels;
namespace App.EndPoints.Home_RepaireUI.Areas.Seller.Controllers
{
    [Area("Seller")]
    public class AuctionController : Controller
    {
        private readonly IMapper _mapper;
       
        private readonly UserManager<AppUser> _userManager;

        public AuctionController(IMapper mapper, UserManager<AppUser> userManager)
        {
            _mapper = mapper;
          
            _userManager = userManager;
        }

        //public Task <IActionResult> Index()
        //{
        //    return View();
        //}
        //public Task<IActionResult> Create(CancellationToken cancellationToken)
        //{
            
        //    return View();
        //}
    }
}
 