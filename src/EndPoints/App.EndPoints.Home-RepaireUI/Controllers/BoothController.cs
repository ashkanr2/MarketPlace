using App.Domain.Core.AppServices.Admins;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using App.EndPoints.Home_RepaireUI.Models.Booth;
namespace App.EndPoints.Home_RepaireUI.Controllers
{
    public class BoothController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IBoothAppservice _boothAppservice;

        public BoothController(IMapper mapper, IBoothAppservice boothAppservice)
        {
            _mapper = mapper;
            _boothAppservice = boothAppservice;
        }
        public async Task<IActionResult> Booths(CancellationToken cancellation)
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

    }
}
