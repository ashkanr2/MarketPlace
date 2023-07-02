using App.Domain.Core.AppServices.Admins;
using Microsoft.AspNetCore.Mvc;
using App.EndPoints.Home_RepaireUI.Models.Product;
using App.Domain.Core.DtoModels;

namespace App.EndPoints.Home_RepaireUI.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductAppservice _productAppservice;

        public ProductController(IProductAppservice productAppservice)
        {
            _productAppservice = productAppservice;
        }

        public async Task<IActionResult> AllProducts(CancellationToken CancellationToken)
        {

            var products = await _productAppservice.GetAll(CancellationToken);
           
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
