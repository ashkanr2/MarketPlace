using App.Domain.Core.AppServices.Admins;
using Microsoft.AspNetCore.Mvc;
using App.EndPoints.Home_RepaireUI.Models.Product;
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
                AllProductId = x.AllProductId,
                IsDeleted = x.IsDeleted,
                IsAccepted = x.IsAccepted,
                boothId = x.BoothId,
                ProductName = x.AllProduct.Name,
            }).ToList();

            return View(ProductViwe);
        }
    }
}
