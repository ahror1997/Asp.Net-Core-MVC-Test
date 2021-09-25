using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Test.Models;

namespace Test.Controllers.Admin
{
    [Route("Admin/[controller]")]
    public class ProductController : Controller
    {
        private readonly ApplicationContext context;

        public ProductController(ApplicationContext _context)
        {
            context = _context;
        }

        [HttpGet]
        [Route("")] //admin/product
        [Route("[action]")]
        public IActionResult Index()
        {
            var categories = context.Products.ToList();
            return View("Views/Admin/Product/Index.cshtml", categories);
        }

        [HttpGet]
        [Route("[action]")]
        public IActionResult Create()
        {
            return View("Views/Admin/Product/Create.cshtml");
        }

        [HttpPost]
        [Route("[action]")]
        public IActionResult Store(Product product)
        {
            context.Products.Add(product);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        [Route("[action]")]
        public IActionResult Edit(int Id)
        {
            Product product = context.Products.Find(Id);
            return View("Views/Admin/Product/Edit.cshtml", product);
        }

        [HttpPost]
        [Route("[action]")]
        public IActionResult Update(Product product)
        {
            context.Products.Update(product);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        [Route("[action]")]
        public IActionResult Delete(int Id)
        {
            Product product = context.Products.Find(Id);
            context.Products.Remove(product);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
