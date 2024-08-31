using Microsoft.AspNetCore.Mvc;
using PD324_01.Data;
using PD324_01.Models;
using PD324_01.Repositories;

namespace PD324_01.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoryController(AppDbContext context, ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public IActionResult Index()
        {
            IEnumerable<Category> categories = _categoryRepository.Categories;

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
        public async Task<IActionResult> Create(Category model)
        {
            if(ModelState.IsValid)
            {
                await _categoryRepository.CreateAsync(model);
                return RedirectToAction("Index");
            }

            return View(model);
        }

        // GET
        public async Task<IActionResult> Update(int? id)
        {
            if(id != null)
            {
                var model = await _categoryRepository.GetByIdAsync((int)id);

                if (model == null)
                {
                    return NotFound();
                }

                return View(model);
            }
            else
            {
                return NotFound();
            }
        }

        // POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(Category model)
        {
            if (ModelState.IsValid)
            {
                await _categoryRepository.UpdateAsync(model);
                return RedirectToAction("Index");
            }

            return View(model);
        }

        // GET
        public async Task<IActionResult> Delete(int? id)
        {
            if (id != null)
            {
                var model = await _categoryRepository.GetByIdAsync((int)id);

                if (model == null)
                {
                    return NotFound();
                }

                return View(model);
            }
            else
            {
                return NotFound();
            }
        }

        // POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(Category model)
        {
            await _categoryRepository.RemoveAsync(model);

            return RedirectToAction("Index");
        }
    }
}
