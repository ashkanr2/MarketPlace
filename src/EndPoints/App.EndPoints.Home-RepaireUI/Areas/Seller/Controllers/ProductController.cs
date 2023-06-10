using App.Domain.Core.AppServices.Admins;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using App.Domain.Core.Entities;
using App.Domain.Core.AppServices.Admin;
using App.Domain.Core.DtoModels;
using App.EndPoints.Home_RepaireUI.Areas.Seller.Models.Product;
using App.EndPoints.Home_RepaireUI.Areas.Admin.Models.User;

namespace App.EndPoints.Home_RepaireUI.Areas.Seller.Controllers
{
    [Area("Seller")]
    public class ProductController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IProductAppservice _productAppservice;
        private readonly IALLProductAppservice _aLLProductAppservice;
        private readonly UserManager<AppUser> _userManager;

        public ProductController(IMapper mapper, IProductAppservice productAppservice, IALLProductAppservice aLLProductAppservice, UserManager<AppUser> userManager)
        {
            _mapper = mapper;
            _productAppservice = productAppservice;
            _aLLProductAppservice = aLLProductAppservice;
            _userManager = userManager;
        }

        public async Task <IActionResult> Index( CancellationToken cancellationToken)
        {
            int boothId = 1;
            var products = await _productAppservice.GetBoothProducts(boothId, cancellationToken);
            var BoothProducts = products.Select(a=>new ProductViewModel {
            Id= a.Id,
            UnitPrice= a.UnitPrice,
            IsAccepted= a.IsAccepted,
            ProductName=a.AllProduct.Name,
            category=a.AllProduct.Category.Title,
            ProductImages=a.ProductImages,
            IsDeleted=a.IsDeleted,

            }).ToList();
           
            return View(BoothProducts);
        }
    }
}
