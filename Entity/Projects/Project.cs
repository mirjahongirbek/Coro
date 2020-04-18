using AuthModel.Enum;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using RepositoryCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Entity.Projects
{
    public class Project:IEntity<string>
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string Name { get; set; }
        public DateTime DateTime { get; set; }
        public UserStatus PrjectStatus { get; set; }
        public List<ProjectServices> ProjectService { get; set; }
        public List<ProjectServer> ProjectServer { get; set; }
        public string Description { get; set; }
        public string AddUserId { get; set; }
        public string Password { get; set; }
        [BsonIgnoreIfDefault()]
        [BsonDefaultValue(true)]
        public bool IsActive { get; set; } = true;
        public ProjectServices GetService(Entity.Enum.Services service)
        {
           return ProjectService.FirstOrDefault(m => m.Services == service);
            
        }

    }
}
