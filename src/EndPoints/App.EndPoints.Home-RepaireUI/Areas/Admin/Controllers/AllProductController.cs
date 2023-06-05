using App.Domain.Core.AppServices.Admin;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace App.EndPoints.Home_RepaireUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AllProductController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IALLProductAppservice _aLLProductAppservice;

        public AllProductController(IMapper mapper, IALLProductAppservice appservice)
        {
            _mapper = mapper;
            _aLLProductAppservice = appservice;
        }

        public async Task <IActionResult> GetAllproducts(CancellationToken cancellation)
        {
            await _aLLProductAppservice.GetAll(cancellation);
            return View("GetAllAllproducts");
        }
        public IActionResult Edite()
        {
            return View();
        }
        public IActionResult Create()
        {
            return View();
        }
        public IActionResult Update()
        {
            return View();
        }

    }
}
