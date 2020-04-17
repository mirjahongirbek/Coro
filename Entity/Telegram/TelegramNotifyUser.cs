using MongoDB.Bson.Serialization.Attributes;
using RepositoryCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entity.Telegram
{
    //public class TelegramNotifyUser:IEntity<string>
    //{
    //    [BsonId]
    //    [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
    //    public string Id { get; set; }
    //    public int TUserId { get; set; }
    //    public long ChatId { get; set; }
    //   public List<NotifyProjects> NotifyProjects { get; set; }
    //}
    public class TelegramUser:IEntity<string>
    {

        [BsonId]
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string Id { get; set; }
        public int TUserId { get; set; }
        public long TChatId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserId { get; set; }
        public string PhoneNumber { get; set; }


    }
}
