using Newtonsoft.Json;

namespace Entity.Sms
{
    public class Sms
    {
        [JsonProperty("originator")]
        public string Originator { get; set; }
        public Content Content { get; set; }
    }
}
