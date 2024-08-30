using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PD324_01.Data;
using PD324_01.Models;
using PD324_01.Models.ViewModels;
using PD324_01.Repositories;
using System.Diagnostics;

namespace PD324_01.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly AppDbContext _context;

        public HomeController(ILogger<HomeController> logger, AppDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            var model = new HomeVM
            {
                Products = _context.Products.Include(p => p.Category),
                Categories = _context.Categories,
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
