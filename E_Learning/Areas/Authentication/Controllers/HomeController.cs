﻿using Microsoft.AspNetCore.Mvc;

namespace E_Learning.Areas.Authentication.Controllers
{
    [Area("Authentication")]
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
