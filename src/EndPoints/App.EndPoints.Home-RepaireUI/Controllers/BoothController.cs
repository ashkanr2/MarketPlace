using App.Domain.Core.AppServices.Admins;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using App.EndPoints.Home_RepaireUI.Models.Booth;
using App.Frameworks.Web;

namespace App.EndPoints.Home_RepaireUI.Controllers
{
    public class BoothController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IBoothAppservice _boothAppservice;
        private readonly DateConvertor _dateConvertor;
        private readonly ICommentAppservice _commentAppservice;
        public BoothController(IMapper mapper, IBoothAppservice boothAppservice, DateConvertor dateConvertor, ICommentAppservice commentAppservice)
        {
            _mapper = mapper;
            _boothAppservice = boothAppservice;
            _dateConvertor = dateConvertor;
            _commentAppservice = commentAppservice;
        }
        public async Task<IActionResult> Booths(CancellationToken cancellation)
        {
            var booths = (await _boothAppservice.GetAll(cancellation))
            .Where(x => x.IsCreated && !x.IsDeleted)
            .ToList();
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
                CreatedDate = _dateConvertor.ConvertToPersianDate(b.CreatedAt)
            }).ToList();
            return View(boothViewModels);

        }
        public async Task<IActionResult>GetBoothDetail(int id, CancellationToken cancellationToken)
        {
            var Item = await _boothAppservice.GetDatail(id, cancellationToken);
            var Booth = new BoothViewModel
            {
                Id = Item.Id,
                Name = Item.Name,
                OwnerUserId = Item.OwnerUserId,
                CreatedAt = Item.CreatedAt,
                Description = Item.Description,
                TotalSalesNumber = Item.TotalSalesNumber,
                BoothImageId = Item.BoothImageId,
                IsDeleted = Item.IsDeleted,
                CityId = Item.CityId,
                IsCreated = Item.IsCreated,
                CreatedDate = _dateConvertor.ConvertToPersianDate(Item.CreatedAt),
                Image = Item.BoothImage,
            };
            var comments = (await _commentAppservice.GetAllBoothComments(id, cancellationToken))
            .Where(a => a.IsAccepted == true && a.IsDeleted == false);

            ViewBag.comments = comments;


            return View(Booth);
        }

    }
}
