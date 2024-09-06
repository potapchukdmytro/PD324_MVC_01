using Microsoft.AspNetCore.Mvc;
using PD324_01.Models;
using PD324_01.Models.ViewModels;
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

            IEnumerable<CartVM> models = new List<CartVM>();

            if (cartListItems.Count > 0)
            {
                models = cartListItems
                    .Select(i => new CartVM
                    {
                        Quantity = i.Quantity,
                        Product = _productRepository.Products.FirstOrDefault(p => p.Id == i.ProductId)
                    });
            }

            return View(models);
        }

        [HttpPost]
        public IActionResult UpdateItemQuantity(int id, int value)
        {
            var listItems = Session.GetCartListItems(HttpContext);

            if (listItems.Count > 0)
            {
                var item = listItems.FirstOrDefault(i => i.ProductId == id);
                
                if(item != null)
                {
                    item.Quantity = value;

                    HttpContext.Session.Set(Settings.SessionKeyCart, listItems);
                }
            }

            return Ok();
        }

        public IActionResult RemoveFromCart(int id)
        {
            CartService.RemoveFromCart(HttpContext, id);

            return RedirectToAction("Index");
        }
    }
}
