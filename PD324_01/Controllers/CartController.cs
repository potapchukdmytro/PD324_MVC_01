using Microsoft.AspNetCore.Mvc;
using PD324_01.Models;
using PD324_01.Repositories;
using PD324_01.Services;

namespace PD324_01.Controllers
{
    public class CartController : Controller
    {
        private readonly IProductRepository _productRepository;

        public CartController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public IActionResult Index()
        {
            var cartListItems = Session.GetCartListItems(HttpContext);

            IEnumerable<Product> models = new List<Product>();

            if (cartListItems.Count > 0)
            {
                models = _productRepository.Products
                    .Where(p => cartListItems.Any(i => i.ProductId == p.Id));
            }

            return View(models);
        }
    }
}
