using Entity.Sms;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using RepositoryCore.Interfaces;
using System;
using System.Diagnostics;

namespace Entity.Message
{
    public class SaveMessage : IEntity<string>
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
        [BsonDefaultValue(true)]
        public bool IsSend { get; set; } = true;
        public string ProjectId { get; set; }
        public long Duration { get; set; }
        [BsonIgnore]
        public Stopwatch StopWatch { get; set; }
        public static SaveMessage Create(SendModal sendModal)
        {
            SaveMessage save = new SaveMessage();
            save.Id = ObjectId.GenerateNewId().ToString();
            save.SendModal = sendModal;
            save.PhoneNumber = sendModal.Messages[0].Recipient;
            save.StopWatch = Stopwatch.StartNew();
            save.CreateDate = DateTime.Now;
            return save;
        }
    }


}
