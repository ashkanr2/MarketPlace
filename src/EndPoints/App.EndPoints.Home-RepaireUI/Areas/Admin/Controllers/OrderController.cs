using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using App.Domain.Core.AppServices.Admins;
using Microsoft.AspNetCore.Authorization;
using App.Domain.Core.DtoModels;
using App.EndPoints.Home_RepaireUI.Areas.Admin.Models;
using App.Domain.Core.AppServices.Admin;

namespace App.EndPoints.Home_RepaireUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class OrderController : Controller
    {
        private readonly IOrderAppservice _orderAppservice;
       
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
           //var orders= await _orderAppservice.GetAllOrders(cancellationToken);
           
            return View(/*orders*/);
        }


    }
}
