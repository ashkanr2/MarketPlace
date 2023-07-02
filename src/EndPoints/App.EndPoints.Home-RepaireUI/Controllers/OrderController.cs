using App.Domain.Core.AppServices.Admin;
using App.Domain.Core.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using App.EndPoints.Home_RepaireUI.Models.Order;
using App.EndPoints.Home_RepaireUI.Models.Product;

namespace App.EndPoints.Home_RepaireUI.Controllers
{
    public class OrderController : Controller
    {
        private readonly IOrderAppservice _orderAppservice;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly UserManager<AppUser> _userManager;
        public OrderController(IOrderAppservice orderAppservice, SignInManager<AppUser> signInManager, UserManager<AppUser> userManager)
        {
            _orderAppservice = orderAppservice;
            _signInManager = signInManager;
            _userManager = userManager;
        }

        public IActionResult Index()
        {
            return View();
        }
        public async Task<IActionResult> Order_delivered(CancellationToken cancellationToken)
        {
            var user = await _userManager.GetUserAsync(User);
            var userId = user.Id;
            var orders = await _orderAppservice.GetAllUserOrders(userId, cancellationToken);
            var ordertViewModels = orders.Select(a => new OrderDetailViewModel
            {
                Id = a.Id,
                OrderCreatTime = a.OrderCreatTime,
                status = a.Status.Title,
                BoothName = a.Booth.Name,
                TotalPrice = a.TotalPrice,
                Commission = a.Commission,
                

            }).ToList();
            return View(ordertViewModels);
        }
    }
}
