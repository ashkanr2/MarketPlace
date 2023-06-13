using App.Domain.Core.AppServices.Admin;
using App.EndPoints.Home_RepaireUI.Areas.Admin.Models.Order;
using Microsoft.AspNetCore.Mvc;

namespace App.EndPoints.Home_RepaireUI.Areas.Seller.Controllers
{
    [Area("Seller")]
    public class OrderController : Controller
    {
        private readonly IOrderAppservice _orderAppservice;

        public OrderController(IOrderAppservice orderAppservice)
        {
            _orderAppservice = orderAppservice;
        }

        [HttpGet]
        public async Task<IActionResult> OrderDetail(int id, CancellationToken cancellation)
        {
            //var Order = await _orderAppservice.GetDatail(id,cancellation);
            //var orderStatus= Order.Status;
            //var ordermodel = new OrderDetailViewModel()
            //{
            //    Id = Order.Id,
            //    BuyerUserId = Order.BuyerUserId,
            //    OrderCreatTime = Order.OrderCreatTime,
            //    TotalPrice = Order.TotalPrice,
            //    status = Order.Status.Title,
            //    BoothName=Order.Booth.Name
            //};
            return View();
        }
        public async Task<IActionResult> GetAllOrders(CancellationToken cancellationToken)
        {
            var orders = await _orderAppservice.GetAllOrders(cancellationToken);


            var ordertViewModels = orders.Select(a => new OrderDetailViewModel
            {
                Id = a.Id,
                UserId = a.UserId,
                OrderCreatTime = a.OrderCreatTime,
                status = a.Status.Title,
                BoothName = a.Booth.Name,
                TotalPrice = a.TotalPrice,
                UserName = a.User.Name,
                Commission = a.Commission,
                BuyerName = a.User.Name,

            }).ToList();


            return View(ordertViewModels);
        }


    }
}
