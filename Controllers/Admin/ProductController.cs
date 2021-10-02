using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.IO;
using System.Linq;
using Test.Models;

namespace Test.Controllers.Admin
{
    [Route("Admin/[controller]")]
    public class ProductController : Controller
    {
        private readonly ApplicationContext context;
        IWebHostEnvironment appEnvironment;

        public ProductController(ApplicationContext _context, IWebHostEnvironment _appEnvironment)
        {
            context = _context;
            appEnvironment = _appEnvironment;
        }

        [HttpGet]
        [Route("")] // admin/product
        [Route("[action]")] // admin/product/index
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
        public IActionResult Store(Product product, IFormFile photo)
        {
            // file upload
            if (photo != null)
            {
                // путь к папке Files
                string path = "/uploads/" + photo.FileName;
                // сохраняем файл в папку Files в каталоге wwwroot
                using (var fileStream = new FileStream(appEnvironment.WebRootPath + path, FileMode.Create))
                {
                    photo.CopyTo(fileStream);
                }
                product.Photo = photo.FileName;
            }

            context.Products.Add(product);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        [Route("[action]/{id}")]
        public IActionResult Show(int Id)
        {
            Product product = context.Products.Find(Id);
            if (product != null)
            {
                ViewData["product"] = product;
                return View("Views/Admin/Product/Show.cshtml");
            }
            return RedirectToAction("Index");


        }

        [HttpGet]
        [Route("[action]/{id}")]
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
