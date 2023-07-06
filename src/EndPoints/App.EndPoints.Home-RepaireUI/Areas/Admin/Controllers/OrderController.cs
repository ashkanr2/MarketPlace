using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using App.Domain.Core.AppServices.Admins;
using Microsoft.AspNetCore.Authorization;
using App.Domain.Core.DtoModels;
using App.EndPoints.Home_RepaireUI.Areas.Admin.Models.Order;
using App.Domain.Core.AppServices.Admin;
using App.Domain.Core.DataAccess;

namespace App.EndPoints.Home_RepaireUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class OrderController : Controller
    {
        private readonly IOrderAppservice _orderAppservice;
        private readonly IAppUserRipositry _appUserRipositry;
        public OrderController(IOrderAppservice orderAppservice, IAppUserRipositry appUserRipositry)
        {
            _orderAppservice = orderAppservice;
            _appUserRipositry = appUserRipositry;
        }

        [HttpGet]
        public async Task<IActionResult> OrderDetail(int id , CancellationToken cancellation)
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
        public async Task <IActionResult> GetAllOrders(CancellationToken cancellationToken)
        {
           var orders = await _orderAppservice.GetAllOrders(cancellationToken);

          
            var ordertViewModels = orders.Select(a => new OrderDetailViewModel
            {
              Id=a.Id,
              UserId=a.UserId,
              OrderCreatTime=a.OrderCreatTime,
              status=a.Status.Title,
              BoothName=a.Booth.Name,
              TotalPrice=a.TotalPrice,
              UserName=a.User.Name,
              Commission=a.Commission,
              BuyerName=a.User.Name,
             
            }).ToList();

            ViewBag.commission= (await _appUserRipositry.GetDetail(1,cancellationToken)).Wallet;
            return View(ordertViewModels);
        }


    }
}
