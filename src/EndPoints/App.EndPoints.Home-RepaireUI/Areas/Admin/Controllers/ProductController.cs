using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using App.Domain.Core.AppServices.Admins;
using Microsoft.AspNetCore.Authorization;
using App.Domain.Core.DtoModels;
using App.EndPoints.Home_RepaireUI.Areas.Admin.Models;
using App.EndPoints.Home_RepaireUI.Areas.Admin.Models.Product;
using System.Drawing.Printing;
using App.EndPoints.Home_RepaireUI.Areas.Admin.Models.Product;
using App.Domain.AppService.Admins;
using Microsoft.CodeAnalysis.VisualBasic.Syntax;

namespace App.EndPoints.Home_RepaireUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductController : Controller
    {
        private readonly IProductAppservice _productAppservice;
        
        private readonly IMapper _mapper;   

        public ProductController(IProductAppservice productAppservice, IMapper mapper)
        {
            _productAppservice = productAppservice;
            _mapper = mapper;
        }

        public async Task<IActionResult> GetAllProduct(CancellationToken CancellationToken)
        {
            
            var products = await _productAppservice.GetAll(CancellationToken);
            var ProductViwe = products.Select(x => new ProductViewModel
            {
                Id = x.Id,
                UnitPrice = x.UnitPrice,
                AllProductId = x.AllProductId,
                IsDeleted = x.IsDeleted,
                IsAccepted = x.IsAccepted,
                AddTime = x.AddTime,
                boothId=x.BoothId,
                ProductName=x.Name,
            }).ToList();

            return View(ProductViwe);
        }
        public async Task<IActionResult> GetBoothProducts(int boothId,CancellationToken cancellation)
        {
           
            var products = await _productAppservice.GetBoothProducts(boothId, cancellation);
            var ProductViwe = products.Select(x => new ProductViewModel
            {
                Id = x.Id,
                UnitPrice = x.UnitPrice,
                AllProductId = x.AllProductId,
                IsDeleted = x.IsDeleted,
                IsAccepted = x.IsAccepted,
                AddTime = x.AddTime,
                boothId = x.BoothId,
                ProductName = x.AllProduct.Name,
            }).ToList();

            return View(ProductViwe);
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

        public async Task<IActionResult> Active(int id, CancellationToken cancellation)
        {
            var product =  await _productAppservice.GetDetail(id, cancellation);
            product.IsAccepted = true;
            await _productAppservice.Update(product, cancellation);
            return RedirectToAction("GetAllProduct", "Product");
        }
       
        public async Task<IActionResult> Diactive(int Id, CancellationToken cancellation)
        {
            var product = await _productAppservice.GetDetail(Id, cancellation);
            product.IsAccepted = false;
            await _productAppservice.Update(product, cancellation);
            return RedirectToAction("GetAllProduct", "Product");
        }
      


    }
}
