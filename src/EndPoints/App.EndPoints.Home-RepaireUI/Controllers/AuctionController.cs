﻿using Microsoft.AspNetCore.Mvc;

namespace App.EndPoints.Home_RepaireUI.Controllers
{
    public class AuctionController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
