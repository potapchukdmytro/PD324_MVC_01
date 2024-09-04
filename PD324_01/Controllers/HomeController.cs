using Microsoft.AspNetCore.Mvc;
using PD324_01.Models;
using PD324_01.Models.ViewModels;
using PD324_01.Repositories;
using PD324_01.Services;
using System.Diagnostics;

namespace PD324_01.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IProductRepository _productRepository;
        private readonly ICategoryRepository _categoryRepository;

        public HomeController(ILogger<HomeController> logger, ICategoryRepository categoryRepository, IProductRepository productRepository)
        {
            _logger = logger;
            _productRepository = productRepository;
            _categoryRepository = categoryRepository;
        }

        public IActionResult Index()
        {
            var model = new HomeVM
            {
                Products = _productRepository.Products,
                Categories = _categoryRepository.Categories,
            };

            return View(model);
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

        public async Task<IActionResult> Details(int id)
        {
            var product = await _productRepository.GetByIdAsync(id);

            if (product == null)
            {
                return NotFound();
            }

            var model = new ProductDetailsVM
            {
                Product = product,
                IsInCart = false
            };

            var cartListItems = Session.GetCartListItems(HttpContext);

            if (cartListItems.Count > 0)
            {
                var res = cartListItems.Find(li => li.ProductId == id);

                if (res != null)
                {
                    model.IsInCart = true;
                }
            }

            return View(model);
        }

        public async Task<IActionResult> AddToCart(int id)
        {
            if (await _productRepository.GetByIdAsync(id) == null)
            {
                return RedirectToAction("Index");
            }

            var cartItem = new CartListItem
            {
                ProductId = id
            };

            var cartListItems = Session.GetCartListItems(HttpContext);

            cartListItems.Add(cartItem);

            HttpContext.Session.Set(Settings.SessionKeyCart, cartListItems);

            return RedirectToAction("Index");
        }

        public IActionResult RemoveFromCart(int id)
        {
            var cartListItems = Session.GetCartListItems(HttpContext);

            if (cartListItems.Count > 0)
            {
                var item = cartListItems.Find(i => i.ProductId == id);

                if (item != null)
                {
                    cartListItems.Remove(item);
                }

                HttpContext.Session.Set(Settings.SessionKeyCart, cartListItems);
            }

            return RedirectToAction("Index");
        }
    }
}
