﻿using DataAccessLayer.Models;
using Microsoft.AspNetCore.Mvc;
using MVC_Blogs.Models;
using Newtonsoft.Json;
using System.Diagnostics;
using System.Text;

namespace MVC_Blogs.Controllers
{
    public class HomeController : Controller
    {

        public IActionResult Index()
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