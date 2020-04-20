using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.Collections.Generic;

namespace Entity.Projects
{
    public class ProjectServices
    {
        public ProjectServices()
        {
            Id = ObjectId.GenerateNewId().ToString();
        }
        public string Id { get; set; }
        public string Name { get; set; }
        public List<ProjectServer> ProjectServers { get; set; } = new List<ProjectServer>();
        public string Password { get; set; }
        [BsonIgnoreIfDefault()]
        [BsonDefaultValue(true)]
        public bool IsActive { get; set; } = true;
        public string UserName { get; set; }
        public Entity.Enum.Services Services { get; set; }
        public List<Config> Configs { get; set; } = new List<Config>();
        public List<ProjectServer> Request { get; set; } = new List<ProjectServer>();

    }
    
}
