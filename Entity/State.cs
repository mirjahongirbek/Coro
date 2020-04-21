using Entity.Projects;
using Entity.ViewModal.Rest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Telegram.Bot;

namespace Entity
{
    public static class State
    {
        public static KeyValuePair<string, string>? UserNamePassword(this Dictionary<string, string> dict)
        {
            if (!dict.ContainsKey("Authorization")) return null;
            var header = dict["Authorization"];
            if (header.ToString().StartsWith("Basic ", StringComparison.OrdinalIgnoreCase))
            {
                var encodedUsernamePassword = header.ToString().Split(' ', 2, StringSplitOptions.RemoveEmptyEntries)[1]?.Trim();

                var result = Encoding.UTF8.GetString(Convert.FromBase64String(encodedUsernamePassword));
                if (!string.IsNullOrEmpty(result))
                {
                    return new KeyValuePair<string, string>(result.Split(':', 2)[0], result.Split(':', 2)[1]);
                }

            }
            return null;

        }

        public static KeyValuePair<string, string>? Coro(this Dictionary<string, string> dict)
        {

            var username = dict.FirstOrDefault(m => m.Key.ToLower() == CoroConfig.CoroUser).Value;
            var pass = dict.FirstOrDefault(m => m.Key.ToLower() == CoroConfig.CoroPassword).Value;
            if (string.IsNullOrEmpty(username) && string.IsNullOrEmpty(pass))
            {
                return null;
            }
            return new KeyValuePair<string, string>(username, pass);
        }
        public static string BaseUrl(string url)
        {
            var proto = url.Split(new string[] { "://" }, 2, StringSplitOptions.None)[0];
            if (url.Contains(@"://"))
                url = url.Split(new string[] { "://" }, 2, StringSplitOptions.None)[1];

            return proto + "://" + url.Split('/')[0] + "/";
        }
        public static void ParseService(ProjectServices service, RestViewModal model)
        {
        

        }
    }
    public static class CoroConfig
    {
        public static string SmsUrl { get; set; } = "http://172.17.9.248:2600/broker-api/send";
        public static TelegramBotClient Client { get; set; }
        public static string CoroUser { get; set; } = "coroname";
        public static string CoroPassword { get; set; } = "coropass";

    }
}
