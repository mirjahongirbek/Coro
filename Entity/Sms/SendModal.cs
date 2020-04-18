using Entity.Projects;
using MongoDB.Bson.Serialization.Attributes;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace Entity.Sms
{
    public class SendModal
    {
        public List<Message> Messages { get; set; }
        public static SendModal Create(Project partner)
        {
            var result = new SendModal();
            result.Messages = new List<Message>();
            return result;
        }
        [BsonIgnore]
        public bool SendOtp { get; set; }
        [JsonIgnore]
        [BsonIgnore]
        public bool IdSendSms { get; set; }
        [JsonIgnore]
        [BsonIgnore]
        public bool IsSended { get; set; } = true;
        [JsonIgnore]
        [BsonIgnore]
        public bool NotSave { get; set; }
        [JsonIgnore]
        [BsonIgnore]
        public string Otp { get; set; } = null;

        [JsonIgnore]
        [BsonIgnore]
        public string Token { get; set; } = null;
        public string UserName { get; set; }
        public string Password { get; set; }
        public void BeforeConfig(ProjectServices partner)
        {
            if(partner== null) { return; }
            UserName = partner.UserName;
            Password = partner.Password;
        }


    }
}
