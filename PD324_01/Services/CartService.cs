using Microsoft.AspNetCore.Mvc;

namespace PD324_01.Services
{
    public static class CartService
    {
        public static void RemoveFromCart(HttpContext httpContext, int id)
        {
            var cartListItems = Session.GetCartListItems(httpContext);

            if (cartListItems.Count > 0)
            {
                var item = cartListItems.Find(i => i.ProductId == id);

                if (item != null)
                {
                    cartListItems.Remove(item);
                }

                httpContext.Session.Set(Settings.SessionKeyCart, cartListItems);
            }
        }
    }
}
