using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PD324_01.Data;
using PD324_01.Models;
using PD324_01.Models.ViewModels;

namespace PD324_01.Controllers
{
    public class ProductController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public ProductController(AppDbContext context, IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            _webHostEnvironment = webHostEnvironment;
        }

        public IActionResult Index()
        {
            IEnumerable<Product> products = _context.Products.Include(p => p.Category);

            return View(products);
        }

        public IActionResult Create()
        {
            var viewModel = new CreateProductVM
            {
                Product = new Product(),
                ListItems = _context.Categories.Select(c =>
                new SelectListItem
                {
                    Text = c.Name,
                    Value = c.Id.ToString()
                })
            };

            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(CreateProductVM model)
        {
            var files = HttpContext.Request.Form.Files;
            var image = files.Count() > 0 ? files[0] : null;
            var rootPath = _webHostEnvironment.WebRootPath;
            string fileName = "";

            if (image != null)
            {
                var types = image.ContentType.Split("/");
                if (types[0] == "image")
                {
                    fileName = Guid.NewGuid().ToString() + "." + types[1];
                    string imagePath = Path.Combine(rootPath, Settings.ProductsImage, fileName);

                    using (var stream = System.IO.File.Create(imagePath))
                    {
                        image.OpenReadStream().CopyTo(stream);
                    }
                }
            }

            model.Product.Image = fileName;
            _context.Products.Add(model.Product);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        // GET
        public IActionResult Update(int? id)
        {
            if(id == null)
            {
                return NotFound();
            }

            var model = _context.Products.AsNoTracking().FirstOrDefault(p => p.Id == id);

            if (model == null)
            {
                return NotFound();
            }

            var viewModel = new CreateProductVM
            {
                Product = model,
                ListItems = _context.Categories.Select(c =>
                new SelectListItem
                {
                    Text = c.Name,
                    Value = c.Id.ToString()
                })
            };

            return View(viewModel);
        }

        // POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Update(CreateProductVM model)
        {
            var files = HttpContext.Request.Form.Files;
            var image = files.Count() > 0 ? files[0] : null;
            var rootPath = _webHostEnvironment.WebRootPath;
            string fileName = "";

            if (image != null)
            {
                var types = image.ContentType.Split("/");
                if (types[0] == "image")
                {
                    fileName = Guid.NewGuid().ToString() + "." + types[1];
                    string oldFileName = model.Product.Image;

                    if(!string.IsNullOrEmpty(oldFileName))
                    {
                        string oldImagePath = Path.Combine(rootPath, Settings.ProductsImage, oldFileName);

                        if (System.IO.File.Exists(oldImagePath))
                        {
                            System.IO.File.Delete(oldImagePath);
                        }
                    }

                    string imagePath = Path.Combine(rootPath, Settings.ProductsImage, fileName);

                    using (var stream = System.IO.File.Create(imagePath))
                    {
                        image.OpenReadStream().CopyTo(stream);
                    }
                }
            }

            model.Product.Image = fileName;
            _context.Products.Update(model.Product);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}
