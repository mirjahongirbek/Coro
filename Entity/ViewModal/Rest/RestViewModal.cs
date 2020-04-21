using Entity.Enum;
using MongoDB.Bson.Serialization.Attributes;
using System.Collections.Generic;
using System.Diagnostics;

namespace Entity.ViewModal.Rest
{
    public class RestViewModal
    {
        public string Url { get; set; }
        public Method Method { get; set; }
        public Dictionary<string, object> Data { get; set; }
        public Entity.Enum.Services Services { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public Dictionary<string, string> Header { get; set; } = new Dictionary<string, string>();
        [BsonIgnore]
        public string FromIp { get; set; }
        public Stopwatch StopWatch { get; set; }
        private string BaseUrls { get; set; }
        public string BaseUrl()
        {
            if (string.IsNullOrEmpty(BaseUrls))
            {
                BaseUrls = Entity.State.BaseUrl(Url);
            }
            return BaseUrls;
        }

    }
}
