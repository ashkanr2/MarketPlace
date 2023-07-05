using App.Domain.Core.AppServices.Admins;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using App.Domain.Core.Entities;
using App.Domain.Core.DtoModels;
using App.Domain.Core.DataAccess;
using System.Threading;
using App.EndPoints.Home_RepaireUI.Areas.Seller.Models.Auction;
using App.Domain.Core.AppServices.Admin;
using System.Drawing.Printing;
using App.Frameworks.Web;

namespace App.EndPoints.Home_RepaireUI.Areas.Seller.Controllers
{
    [Area("Seller")]
    public class AuctionController : Controller
    {
        private readonly IMapper _mapper;
       
        private readonly UserManager<AppUser> _userManager;
        private readonly IProductAppservice _productAppservice;
        private readonly IAuctionAppservice _auctionAppservice;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly IBoothAppservice _boothAppservice;
        private readonly DateConvertor dateConvertor;
        public AuctionController(UserManager<AppUser> userManager,
            IProductAppservice productAppservice,
            SignInManager<AppUser> signInManager,
            IBoothAppservice boothAppservice,
            IAuctionAppservice auctionAppservice,
            DateConvertor dateConvertor)
        {
            _userManager = userManager;
            _productAppservice = productAppservice;
            _signInManager = signInManager;
            _boothAppservice = boothAppservice;
            _auctionAppservice = auctionAppservice;
            this.dateConvertor = dateConvertor;
        }

        public async Task <IActionResult> GetAllAuction(CancellationToken cancellationToken)
        {
            var userId = (await _signInManager.UserManager.GetUserAsync(User)).Id;
            var boothId = (await _boothAppservice.Getbooth(userId, cancellationToken))?.Id;
           if(boothId == null)
            {
                return RedirectToAction("Index","Home");
            }
                var Auctions = await _auctionAppservice.GetAll(boothId ?? default(int), cancellationToken);
                var AuctionView = Auctions.Select(async a => new AuctionViewModel
                {
                    Id = a.Id,
                    StartTime = a.StartTime,
                    EndTime = a.EndTime,
                    Product = a.Product,
                    ProductId = a.ProductId,
                    Bids = a.Bids,
                    StaredTime= dateConvertor.ConvertToPersianDate(a.StartTime),
                    EndedTime=dateConvertor.ConvertToPersianDate(a.EndTime),
                }).ToList();
            
            return View(AuctionView);
            
        }
        public async Task<IActionResult> Create(CancellationToken cancellationToken)
        {
            var userId = (await _signInManager.UserManager.GetUserAsync(User)).Id;
            var boothId = (await _boothAppservice.Getbooth(userId, cancellationToken)).Id;
            var products = (await _productAppservice.GetBoothProducts(boothId, cancellationToken))
             .Where(a => a.IsAvailable && !a.IsDeleted && a.IsAccepted);

            ViewBag.Products = products;

            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(AuctionViewModel auction,CancellationToken cancellationToken)
        {
            
            var auctionDto = new AuctionDto
            {
                Id = auction.Id,
                StartTime = auction.StartTime,
                EndTime=auction.EndTime,
                ProductId = auction.ProductId,

            };
            await _auctionAppservice.Create(auctionDto, cancellationToken);
            
            return RedirectToAction("Index","Home");

        }


    }
}
 