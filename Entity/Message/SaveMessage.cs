using Entity.Sms;
using MongoDB.Bson.Serialization.Attributes;
using RepositoryCore.Interfaces;
using System;

namespace Entity.Message
{
    public class SaveMessage:IEntity<string>
    {
        [BsonId]
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string Id { get; set; }
        public string PhoneNumber { get; set; }
        [BsonIgnoreIfNull]
        public SendModal SendModal { get; set; }
        [BsonIgnoreIfDefault]
        public string Otp { get; set; }
        [BsonIgnoreIfDefault]
        public string Token { get; set; }
        [BsonIgnoreIfDefault]
        public int OtpId { get; set; } 
        public DateTime CreateDate { get; set; }
        [BsonIgnoreIfDefault]
        public bool IsSend { get; set; } = true;
        public string PartnerId { get; set; }
    }

   
}
