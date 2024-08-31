using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PD324_01.Models;
using PD324_01.Models.Identity;
using PD324_01.Models.ViewModels;
using PD324_01.Repositories;
using System.Diagnostics;

namespace PD324_01.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IProductRepository _productRepository;
        private readonly ICategoryRepository _categoryRepository;
        private readonly UserManager<User> _userManager;

        public HomeController(ILogger<HomeController> logger, ICategoryRepository categoryRepository, IProductRepository productRepository, UserManager<User> userManager)
        {
            _logger = logger;
            _productRepository = productRepository;
            _categoryRepository = categoryRepository;
            _userManager = userManager;
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
    }
}
