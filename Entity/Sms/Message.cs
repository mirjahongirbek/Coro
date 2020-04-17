using Newtonsoft.Json;


namespace Entity.Sms
{
    public class Message
    {
        public string Recipient { get; set; }
        [JsonProperty("message-id")]
        public string MessageId { get; set; }
        public string Priority { get; set; }
        public Sms Sms { get; set; }
    }
}
