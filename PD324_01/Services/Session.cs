using PD324_01.Models;
using System.Text.Json;

namespace PD324_01.Services
{
    public static class Session
    {
        public static void Set<T>(this ISession session, string key, T value)
        {
            session.SetString(key, JsonSerializer.Serialize(value));
        }

        public static T Get<T>(this ISession session, string key)
        {
            var data = session.GetString(key);
            return data == null ? default : JsonSerializer.Deserialize<T>(data);
        }

        public static List<CartListItem> GetCartListItems(HttpContext context)
        {
            var result = new List<CartListItem>();

            if (context.Session.Get<List<CartListItem>>(Settings.SessionKeyCart) != null)
            {
                result = context.Session.Get<List<CartListItem>>(Settings.SessionKeyCart);
            }

            return result;
        }
    }
}
