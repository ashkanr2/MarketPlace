using App.Domain.Core.AppServices.Admin;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using App.Domain.Core.Entities;
using App.EndPoints.Home_RepaireUI.Models.Cart;
using App.EndPoints.Home_RepaireUI.Models.Product;

namespace App.EndPoints.Home_RepaireUI.Controllers
{
    public class CartController : Controller
    {
        private readonly ICartAppservice _appservice;
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        public CartController(ICartAppservice appservice, UserManager<AppUser> userManager, SignInManager<AppUser> signInManager)
        {
            _appservice = appservice;
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public async Task <IActionResult> Index(int cartId , CancellationToken cancellationToken)
        {
            
            var cart = await _appservice.GetDatail(cartId,cancellationToken);

            if (cart == null)
            {
                // Handle case where cart does not exist
                return NotFound();
            }

            //var userId = (await _signInManager.UserManager.GetUserAsync(User)).Id;
            int UserId = 11;
            var cartViewModel = new CartViewModel
            {
                Id = cart.Id,
                UserId = cart.UserId,
                CreateTime = cart.CreateTime,
                CartProducts = cart.CartProducts.Select(cp => new ProductViewModel
                {
                    Id = cp.Product.Id,
                    UnitPrice = cp.Product.UnitPrice,
                    boothId = cp.Product.BoothId,
                    ProductName = cp.Product.Name,
                    
                }).ToList()
            };
            return View(cartViewModel);
        }

        public async Task<IActionResult> List(CancellationToken cancellationToken)
        {
            var user = await _userManager.GetUserAsync(User);
            //var userId = user.Id;
            int userId = 11;
            var allCarts = await _appservice.GetAllUserCarts(userId, cancellationToken);

            var cartViewModels = allCarts.Select(a => new CartViewModel
            {
                Id = a.Id,
                UserId = a.UserId,
                BoothId = a.BoothId,
                CreateTime = a.CreateTime,
                CartProducts = a.CartProducts.Select(cp => new ProductViewModel
                {
                    Id = cp.Product.Id,
                    UnitPrice = cp.Product.UnitPrice,
                    boothId =a.BoothId,
                    ProductName = cp.Product.Name,
                }).ToList()
            }).ToList();

            return View(cartViewModels);
        }

    }
}
