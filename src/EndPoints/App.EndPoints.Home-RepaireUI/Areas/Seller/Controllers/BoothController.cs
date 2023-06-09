using App.Domain.Core.AppServices.Admins;
using App.Domain.Core.DtoModels;
using App.EndPoints.Home_RepaireUI.Areas.Seller.Models.Booth;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using App.Domain.Core.Entities;

namespace App.EndPoints.Home_RepaireUI.Areas.Seller.Controllers
{
    [Area("Seller")]
    public class BoothController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IBoothAppservice _boothAppservice;
        private readonly UserManager<AppUser> _userManager;
        public BoothController(IMapper mapper, IBoothAppservice boothAppservice, UserManager<AppUser> userManager)
        {
            _mapper = mapper;
            _boothAppservice = boothAppservice;
            _userManager = userManager;
        }

        public IActionResult Index()
        {
            //listi az peygiri darkhast ha neshon bede
            return View();
        }

        public async Task <IActionResult> Edit(int boothId, CancellationToken cancellationToken)
        {
          var booth = await _boothAppservice.GetDatail(boothId, cancellationToken);

            return View(booth);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(BoothDto booth, CancellationToken cancellationToken)
        {
           await _boothAppservice.Update(booth, cancellationToken);

            return RedirectToAction("Index");
        }

        public IActionResult Create()
        {
            
            return View();
        }
        [HttpPost]
        public async Task <IActionResult> Create(BoothViewModel booth , CancellationToken cancellationToken)
        {
            var user = await _userManager.GetUserAsync(User);
            var userId = user.Id;

            BoothDto newBooth =  new BoothDto
            {Name = booth.Name,
             OwnerUserId= userId,
             Description=booth.Description,
             CityId=booth.cityId,
             TotalSalesNumber=booth.TotalSales,
             CreatedAt = DateTime.Now,
             IsCreated =false,
             IsDeleted=false,
            };
            await _boothAppservice.Create(newBooth, cancellationToken);
            return RedirectToAction("Index");
        }
        public IActionResult Delete()
        {
            return View();
        }
    }
}
