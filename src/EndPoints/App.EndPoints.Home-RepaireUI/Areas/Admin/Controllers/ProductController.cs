using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using App.Domain.Core.AppServices.Admins;
using Microsoft.AspNetCore.Authorization;
using App.Domain.Core.DtoModels;
using App.EndPoints.Home_RepaireUI.Areas.Admin.Models;
using App.EndPoints.Home_RepaireUI.Areas.Admin.Models.Comment;
using System.Drawing.Printing;
using App.EndPoints.Home_RepaireUI.Areas.Admin.Models.Product;
using App.Domain.AppService.Admins;

namespace App.EndPoints.Home_RepaireUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductController : Controller
    {
        private readonly IProductAppservice _productAppservice;
        
        private readonly Mapper _mapper;

        public ProductController(IProductAppservice productAppservice, Mapper mapper)
        {
            _productAppservice = productAppservice;
            _mapper = mapper;
        }

        public async Task<IActionResult> GetAllProduct ()
        {
            //await _productAppservice.
            return View();
        }
        public async Task<IActionResult> GetBoothProducts(int boothId,CancellationToken cancellation)
        {
            var products = await _productAppservice.GetBoothProducts(boothId, cancellation);
            var ProductViwe = products.Select(x => new ProductViewModel
            {
                Id= x.Id,
                UnitPrice= x.UnitPrice,
                AllProductId=x.AllProductId,
                IsDeleted=x.IsDeleted,
                IsAccepted=x.IsAccepted,
                AddTime=x.AddTime,
                
            }).ToList();

            return View(ProductViwe);
        }
        [HttpPost]
        public async Task<IActionResult> Active(int productId, CancellationToken cancellation)
        {
            await _productAppservice.Active(productId, cancellation);
            return RedirectToAction("Index","Home");
        }
        [HttpPost]
        public async Task<IActionResult> Diactive(int productId, CancellationToken cancellation)
        {
            await _productAppservice.Active(productId, cancellation);
            return RedirectToAction("Index", "Home");
        }
        [HttpPost]
        public async Task<IActionResult> Update(ProductDto product, CancellationToken cancellation)
        {
            await _productAppservice.Update(product, cancellation);
            int boothId = product.BoothId;
            return RedirectToAction("GetBoothProducts","product","boothId");
        }
    }
}
