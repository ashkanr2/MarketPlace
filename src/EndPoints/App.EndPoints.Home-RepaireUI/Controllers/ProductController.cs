using App.Domain.Core.AppServices.Admins;
using Microsoft.AspNetCore.Mvc;
using App.EndPoints.Home_RepaireUI.Models.Product;
using App.Domain.Core.DtoModels;
using App.Domain.Core.AppServices.Admin;

namespace App.EndPoints.Home_RepaireUI.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductAppservice _productAppservice;
        private readonly IAuctionAppservice _auctionAppservice;
        private readonly IMotherCategoryAppservice _motherCategoryAppservice;
        private readonly IBoothAppservice _boothAppservice;
        public ProductController(IProductAppservice productAppservice, IAuctionAppservice auctionAppservice, IMotherCategoryAppservice motherCategoryAppservice)
        {
            _productAppservice = productAppservice;
            _auctionAppservice = auctionAppservice;
            _motherCategoryAppservice = motherCategoryAppservice;
        }

        public async Task<IActionResult> AllProducts(CancellationToken CancellationToken)
        {

            var Items = await _productAppservice.GetAll(CancellationToken.None);
            var products = Items.Where(p => !p.IsDeleted && p.IsAccepted && p.IsAvailable).ToList();

            var ProductViwe = products.Select(x => new ProductViewModel
            {
                Id = x.Id,
                UnitPrice = x.UnitPrice,
                boothId = x.BoothId,
                ProductName = x.Name,
                ImagesPaths = x.ProductImages.Select(pi =>
                {
                    string[] parts = pi.Image.Path.Split("_+_");
                    return parts[0];
                }).ToList()
            }).ToList();
            return View(ProductViwe);
        }
        public async Task<IActionResult> ProductCategory(int motherCategoryId, CancellationToken CancellationToken)
        {
            var products = await _productAppservice.GetMCAtegoryProducts(motherCategoryId, CancellationToken);
            var ProductViwe = products.Select(x => new ProductViewModel
            {
                Id = x.Id,
                UnitPrice = x.UnitPrice,
                boothId = x.BoothId,
                ProductName = x.Name,
                ImagesPaths = x.ProductImages.Select(pi =>
                {
                    string[] parts = pi.Image.Path.Split("_+_");
                    return parts[0];
                }).ToList()
            }).ToList();

            return View(ProductViwe);
        }
        public async Task<IActionResult> AuctionProducts(CancellationToken CancellationToken)
        {
            var Items = await _productAppservice.GetAll(CancellationToken.None);
            var products = Items.Where(p => !p.IsDeleted && p.IsAccepted && p.IsAvailable).ToList();
            var ProductViwe = products.Select(x => new ProductViewModel
            {
                Id = x.Id,
                UnitPrice = x.UnitPrice,
                boothId = x.BoothId,
                ProductName = x.Name,
                ImagesPaths = x.ProductImages.Select(pi =>
                {
                    string[] parts = pi.Image.Path.Split("_+_");
                    return parts[0];
                }).ToList()
            }).ToList();
            return View(ProductViwe);


        }
        public async Task<IActionResult> BoothProduct(int boothId, CancellationToken cancellationToken)
        {
            var Items = await _productAppservice.GetAll(CancellationToken.None);
            var products = Items.Where(p => !p.IsDeleted && p.IsAccepted && p.IsAvailable).ToList();
            var ProductViwe = products.Select(x => new ProductViewModel
            {
                Id = x.Id,
                UnitPrice = x.UnitPrice,
                boothId = x.BoothId,
                ProductName = x.Name,
                ImagesPaths = x.ProductImages.Select(pi =>
                {
                    string[] parts = pi.Image.Path.Split("_+_");
                    return parts[0];
                }).ToList()
            }).ToList();
            return View(ProductViwe);

           
        }

    }
}
