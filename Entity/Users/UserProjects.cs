using AuthModel.Enum;
using MongoDB.Bson.Serialization.Attributes;
using RepositoryCore.Interfaces;
using System;

namespace Entity.Users
{
    public class UserProjects:IEntity<string>
    {
        [BsonId]
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string Id { get; set; }
        public string ProjectId { get; set; }
        public string ProjectName { get; set; }
        public string UserId { get; set; }
        public DateTime AddDate { get; set; }
        public UserStatus UserStatus { get; set; }
        public string AddUserId { get; set; }
    }
}
    
