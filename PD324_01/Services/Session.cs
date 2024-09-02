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
    }
}
