﻿using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using View.Models;

namespace View.Controllers
{
    public class UIController : Microsoft.AspNetCore.Mvc.Controller
    {
        private readonly ILogger<HomeController> _logger;

        public UIController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {

            //if (HttpContext.Session.GetString("UserId") == null)
            //{
            //    return RedirectToAction("Login", "Login");
            //}
            return View();
        }
        public IActionResult CartIndex()
        {
            return View();
        }
        public IActionResult OrdersList()
        {
            return View();
        }
        public IActionResult Bills()
        {
            return View();
        }
        public IActionResult Details()
        {
            return View();
        }
        public IActionResult UserCreate()
        {
            return View();
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
