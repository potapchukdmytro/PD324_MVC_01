using Microsoft.AspNetCore.Mvc;
using PD324_01.Data;
using PD324_01.Models;
using PD324_01.Repositories;

namespace PD324_01.Controllers
{
    public class CategoryController : Controller
    {
        private readonly AppDbContext _context;
        private readonly ICategoryRepository _categoryRepository;

        public CategoryController(AppDbContext context, ICategoryRepository categoryRepository)
        {
            _context = context;
            _categoryRepository = categoryRepository;
        }

        public IActionResult Index()
        {
            IEnumerable<Category> categories = _context.Categories;

            return View(categories);
        }

        // GET
        public IActionResult Create()
        {
            return View();
        }

        // POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Category model)
        {
            if(!string.IsNullOrEmpty(model.Name))
            {
                _context.Categories.Add(model);
                _context.SaveChanges();
            }

            return RedirectToAction("Index");
        }

        public IActionResult Update(int? id)
        {
            if(id != null)
            {
                var model = _categoryRepository.GetById((int)id);
                return View(model);
            }
            else
            {
                return RedirectToAction("Index");
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Update(Category model)
        {
            _context.Categories.Update(model);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        public IActionResult Delete(int? id)
        {
            var model = _context.Categories.Find(id);
            _context.Remove(model);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}
