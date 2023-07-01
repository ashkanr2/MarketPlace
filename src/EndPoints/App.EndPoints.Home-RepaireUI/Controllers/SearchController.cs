using App.Domain.Core.AppServices.Admins;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using App.EndPoints.Home_RepaireUI.Models.Product;

namespace App.EndPoints.Home_RepaireUI.Controllers
{
    public class SearchController : Controller
    {
        private readonly IProductAppservice _productAppservice;
        private readonly IMapper _mapper;
        private readonly ILogger<HomeController> _logger;
        public SearchController(IProductAppservice productAppservice, ILogger<HomeController> logger, IMapper mapper)
        {
            _productAppservice = productAppservice;
            _logger = logger;
            _mapper = mapper;
        }

        public async Task<IActionResult> Result(string item , CancellationToken cancellationToken)
        {
           var items =await _productAppservice.Search(item, cancellationToken);
            var products = items.Select(x => new ProductViewModel
            {
                Id = x.Id,
                UnitPrice = x.UnitPrice,
                AllProductId = x.AllProductId,
                IsDeleted = x.IsDeleted,
                IsAccepted = x.IsAccepted,
                ProductImages = x.ProductImages,
                boothId = x.BoothId,
                ProductName = x.AllProduct.Name,
            }).ToList();
           
            return View(products);
        }
    }
}
