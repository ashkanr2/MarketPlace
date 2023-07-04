using App.Domain.Core.AppServices.Admin;
using App.Domain.Core.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using App.EndPoints.Home_RepaireUI.Models.Order;
using App.EndPoints.Home_RepaireUI.Models.Product;
using App.Frameworks;
using App.Frameworks.Web;
using App.Domain.Core.AppServices.Admins;
using App.Domain.Core.DtoModels;

namespace App.EndPoints.Home_RepaireUI.Controllers
{
    public class OrderController : Controller
    {
        private readonly IOrderAppservice _orderAppservice;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly UserManager<AppUser> _userManager;
        private readonly ICommentAppservice _commentAppservice;
        private readonly DateConvertor _dateConvertor;
        public OrderController(IOrderAppservice orderAppservice, SignInManager<AppUser> signInManager, UserManager<AppUser> userManager, DateConvertor dateConvertor, ICommentAppservice commentAppservice)
        {
            _orderAppservice = orderAppservice;
            _signInManager = signInManager;
            _userManager = userManager;
            _dateConvertor = dateConvertor;
            _commentAppservice = commentAppservice;
        }

        public IActionResult Index()
        {
            return View();
        }
        public async Task<IActionResult> Delivered(CancellationToken cancellationToken)
        {
            var user = await _userManager.GetUserAsync(User);
            var userId = 3;
            var orders = await _orderAppservice.GetAllUserOrders(userId, cancellationToken);
            var ordertViewModels = orders.Select(a => new OrderDetailViewModel
            {
                Id = a.Id,
                OrderCreatTime = a.OrderCreatTime,
                status = a.Status.Title,
                BoothName = a.Booth.Name,
                TotalPrice = a.TotalPrice,
                Commission = a.Commission,
                ShamsiDate = _dateConvertor.ConvertToPersianDate(a.OrderCreatTime),

            }).ToList();
            return View(ordertViewModels);
        }
        public async Task<IActionResult> Comments(CancellationToken cancellationToken)
        {
            var userId = 3;
            var allcomments = await _commentAppservice.GetAllUser(3, cancellationToken);
            return View(allcomments);

        }
        public async Task<IActionResult> CreateComments(CancellationToken cancellationToken)
        {
            return View();

        }
        [HttpPost]
        public IActionResult Create(CommentDto comment)
        {
           
            if (ModelState.IsValid)
            {
               
                

                return RedirectToAction("Index", "Home"); 
            }
            else
            {
                return View(comment);
            }
        }

    }

}
