﻿using Microsoft.AspNetCore.Mvc;

namespace LostArkOffice.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.Title = "Home";
            return View();
        }
    }
}
