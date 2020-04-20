using System.Collections.Generic;
using System.Linq;
using Telegram.Bot;

namespace Entity
{
    public static class State
    {
       
        public static KeyValuePair<string, string> Coro(this Dictionary<string, string> dict)
        {

            var username = dict.FirstOrDefault(m => m.Key.ToLower() == CoroConfig.CoroUser).Value.ToString();
            var pass = dict.FirstOrDefault(m => m.Key.ToLower() == CoroConfig.CoroPassword).Value.ToString();
            if(string.IsNullOrEmpty(username) && string.IsNullOrEmpty(pass))
            {

            }
            return new KeyValuePair<string, string>(username, pass);
        }
    }
    public static class CoroConfig
    {
        public static string SmsUrl { get; set; }
        public static TelegramBotClient Client { get; set; }
        public static string CoroUser { get; set; } = "coroname";
        public static string CoroPassword { get; set; }="coropass";

    }
}
