using App.Domain.Core.AppServices.Admin;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using App.Domain.Core.Entities;
using App.EndPoints.Home_RepaireUI.Models.Cart;
using App.EndPoints.Home_RepaireUI.Models.Product;
using App.Domain.Core.AppServices.Admins;
using App.EndPoints.Home_RepaireUI.Models.Order;
using System.Drawing.Printing;
using App.Domain.Core.DtoModels;
using App.Domain.Core.DataAccess;
using AutoMapper;

namespace App.EndPoints.Home_RepaireUI.Controllers
{
    public class CartController : Controller
    {
        private readonly ICartAppservice _appservice;
        private readonly IMapper _mapper;
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly IBoothAppservice _boothAppservice;
        private readonly ICartAppservice _cartAppservice;
        private readonly IOrderAppservice _orderAppservice;
        private readonly IAppUserRipositry _appUserRipositry;
        private readonly IProductAppservice _productAppservice;
        public CartController(ICartAppservice appservice, UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, IBoothAppservice boothAppservice, ICartAppservice cartAppservice, IOrderAppservice orderAppservice, IAppUserRipositry appUserRipositry, IProductAppservice productAppservice, IMapper mapper)
        {
            _appservice = appservice;
            _userManager = userManager;
            _signInManager = signInManager;
            _boothAppservice = boothAppservice;
            _cartAppservice = cartAppservice;
            _orderAppservice = orderAppservice;
            _appUserRipositry = appUserRipositry;
            _productAppservice = productAppservice;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index(int cartId, CancellationToken cancellationToken)
        {
            var cart = await _appservice.GetDatail(cartId, cancellationToken);

            if (cart == null)
            {
                return NotFound();
            }

            int totalprice = cart.CartProducts.Sum(cp => cp.Product.UnitPrice);

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
                }).ToList(),
                TotalPrice = totalprice 
            };

            return View(cartViewModel);
        }
        public async Task<IActionResult> List(CancellationToken cancellationToken)
        {
            var user = await _userManager.GetUserAsync(User);
            int userId = 11; 
           
            //var userId = user.Id;
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
                    boothId = a.BoothId,
                    ProductName = cp.Product.Name
                }).ToList(),
                TotalPrice = a.CartProducts.Sum(cp => cp.Product.UnitPrice) 
            }).ToList();
            return View(cartViewModels);
        }
        public async Task<IActionResult> PaymentMethod(int totalPrice, int cartId)
        {
            ViewBag.TotalPrice = totalPrice;
            ViewBag.cartId = cartId;
            return View();
        }
        public async Task <IActionResult> SuccessfulPayment(int totalPrice, int cartId,CancellationToken cancellationToken)
        {
            ViewBag.TotalPrice = totalPrice;
            var user = _mapper.Map<AppUserDto>(await _signInManager.UserManager.GetUserAsync(User));
            
            if (user.Wallet>=totalPrice)
            {
                var orderId = await _cartAppservice.CreateOrder(cartId, user, cancellationToken);
                ViewBag.OrderId=orderId;
            }
            else
            {
                ViewBag.error = "موجودی کافی نیست ";
                return RedirectToAction("Home", "Inventory");
            }

            return View();
        }
    }
}
