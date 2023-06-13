using App.Domain.Core.AppServices.Admins;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using App.Domain.Core.Entities;
using App.Domain.Core.AppServices.Admin;
using App.Domain.Core.DtoModels;
using App.EndPoints.Home_RepaireUI.Areas.Seller.Models.Product;
using App.EndPoints.Home_RepaireUI.Areas.Admin.Models.User;
using App.Domain.Core.DataAccess;

namespace App.EndPoints.Home_RepaireUI.Areas.Seller.Controllers
{
    [Area("Seller")]
    public class ProductController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IProductAppservice _productAppservice;
        private readonly IALLProductAppservice _aLLProductAppservice;
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly IBoothAppservice _boothAppservice;
        public ProductController(IMapper mapper, IProductAppservice productAppservice, IALLProductAppservice aLLProductAppservice, UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, IBoothAppservice boothAppservice)
        {
            _mapper = mapper;
            _productAppservice = productAppservice;
            _aLLProductAppservice = aLLProductAppservice;
            _userManager = userManager;
            _signInManager = signInManager;
            _boothAppservice = boothAppservice;
        }

        public async Task <IActionResult> Index( CancellationToken cancellationToken)
        {
            var userId = (await _signInManager.UserManager.GetUserAsync(User)).Id;
            var boothId = (await _boothAppservice.Getbooth(userId, cancellationToken))?.Id;
            if(boothId == null )
            {
                return RedirectToAction("Index", "Home");
            }   
            else
            {
                var products = await _productAppservice.GetBoothProducts(boothId.Value, cancellationToken);
                var BoothProducts = products.Select(a => new ProductViewModel
                {
                    Id = a.Id,
                    UnitPrice = a.UnitPrice,
                    IsAccepted = a.IsAccepted,
                    ProductName = a.Name,
                    category = a.AllProduct.Category.Title,
                    ProductImages = a.ProductImages,
                    IsDeleted = a.IsDeleted,
                    Allproduct=a.AllProduct.Name,
                }).ToList();

                return View(BoothProducts);
            }

        }
        public async Task<IActionResult> Detail(int id, CancellationToken cancellation)
        {

            var product = await _productAppservice.GetDetail(id, cancellation);
            var productview = new ProductViewModel
            {
                Id = product.Id,
                UnitPrice = product.UnitPrice,
                IsAccepted = product.IsAccepted,
                boothId = product.BoothId,
                ProductName = product.Name,
                Allproduct = product.AllProduct.Name,
                //ProductImages= product.ProductImages,
            };
            return View(productview);
        }
        public async Task<IActionResult> Update(int id, CancellationToken cancellation)
        {
           
           var product = await _productAppservice.GetDetail(id, cancellation);
            var productview = new ProductViewModel
            {
                Id=product.Id,
                UnitPrice = product.UnitPrice,
                IsAccepted = product.IsAccepted,
                boothId= product.BoothId,
                ProductName= product.Name,
                AllProductId= product.AllProductId,
                //ProductImages= product.ProductImages,
            };
            return View(productview);
        }

        [HttpPost]
        public async Task<IActionResult> Update(ProductViewModel entity, CancellationToken cancellation)
        {
            var info = await _productAppservice.GetDetail(entity.Id, cancellation);
            var product = new ProductDto
            {
                Id = entity.Id,
                Name = entity.ProductName,
                IsDeleted = entity.IsDeleted,
                UnitPrice= entity.UnitPrice,
                BoothId=info.BoothId,
                IsAccepted=info.IsAccepted,
                AllProductId=entity.AllProductId,
                IsAvailable=info.IsAvailable,
                AddTime=info.AddTime,
                
            };
            await _productAppservice.Update(product, cancellation);
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> OnDelete (int Id, CancellationToken cancellation)
        {
            await _productAppservice.OnDelete(Id, cancellation);
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> Delete(int Id, CancellationToken cancellation)
        {
            await _productAppservice.SoftDelete(Id, cancellation);
            return RedirectToAction("Index");
        }
    }
}
