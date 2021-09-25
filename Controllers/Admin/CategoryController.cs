using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Test.Models;

namespace Test.Controllers.Admin
{
    public class CategoryController : Controller
    {
        private readonly ApplicationContext _context;

        public CategoryController(ApplicationContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("Admin/[controller]/[action]")]
        public IActionResult Index()
        {
            var categories = _context.Categories.ToList();
            return View("Views/Admin/Category/Index.cshtml", categories);
        }

        [HttpGet]
        [Route("Admin/[controller]/[action]")]
        public IActionResult Create()
        {
            return View("Views/Admin/Category/Create.cshtml");
        }

        [HttpPost]
        public IActionResult Store(Category category)
        {
            _context.Categories.Add(category);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}
