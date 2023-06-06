using App.Domain.AppService.Admins;
using App.Domain.Core.AppServices.Admins;
using App.EndPoints.Home_RepaireUI.Areas.Admin.Models.Booth;
using App.EndPoints.Home_RepaireUI.Areas.Admin.Models.Comment;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace App.EndPoints.Home_RepaireUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class BoothController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IBoothAppservice _boothAppservice;

        public BoothController(IMapper mapper, IBoothAppservice boothAppservice)
        {
            _mapper = mapper;
            _boothAppservice = boothAppservice;
        }

        public async Task<IActionResult> GetAllBooths(CancellationToken cancellation)
        {
            var booths = await _boothAppservice.GetAll(cancellation);
            var boothViewModels = booths.Select(b => new BoothViewModel
            {
                Id = b.Id,
                Name = b.Name,
                OwnerUserId = b.OwnerUserId,
                CreatedAt = b.CreatedAt,
                Description = b.Description,
                TotalSalesNumber = b.TotalSalesNumber,
                BoothImageId = b.BoothImageId,
                IsDeleted = b.IsDeleted,
                CityId = b.CityId,
                IsCreated = b.IsCreated,
            }).ToList();
            return View(boothViewModels);

        }
      
        public async Task<IActionResult>Active(int id , CancellationToken cancellationToken)
        {
            await _boothAppservice.Active(id, cancellationToken);
            return RedirectToAction("GetAllBooths");
        }
      
        public async Task<IActionResult> Diactivated(int id, CancellationToken cancellationToken)
         {
            await _boothAppservice.DiActive(id, cancellationToken);
            return RedirectToAction("GetAllBooths");
        }
    }
}
