using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using RepositoryCore.Interfaces;
using System;

namespace Entity.Db
{
    public class DeleteData :IEntity<string>
    {
        [BsonId]
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string Id { get; set; }
        public BsonDocument Document { get; set; }
        public DateTime DateTime { get; set; }
        public int UserId { get; set; }

    }
}
