using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Test.Models;

namespace Test.Controllers
{
    public class HomeController : Controller
    {
        //private readonly ILogger<HomeController> _logger;

        private ApplicationContext myDbContext;
        
        public HomeController(ApplicationContext context)
        {
            myDbContext = context;
        }

        //public HomeController(ILogger<HomeController> logger)
        //{
        //    _logger = logger;
        //}

        [HttpGet]
        public IList<Category> CategoryList()
        {
            return (this.myDbContext.Categories.ToList());
        }

        public IActionResult Index()
        {
            ViewBag.Category = new Category();
            return View();
        }

        public IActionResult Privacy()
        {
            ViewData["Message"] = "message from privacy()";
            return View();
        }

        [Route("[controller]/[action]/asdas")]
        public IActionResult About()
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
