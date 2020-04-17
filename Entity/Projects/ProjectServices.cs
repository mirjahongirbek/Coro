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
        public List<ProjectServer> ProjectServers { get; set; }
        public string Password { get; set; }
        [BsonIgnoreIfDefault(true)]
        public bool IsActive { get; set; } = true;
        public string UserName { get; set; }
        public Entity.Enum.Services Services { get; set; }
        public List<Config> Configs { get; set; } = new List<Config>();

    }
}
