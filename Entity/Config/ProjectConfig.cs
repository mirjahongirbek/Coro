using Entity.Projects;
using MongoDB.Bson.Serialization.Attributes;
using RepositoryCore.Interfaces;
using System;
using System.Collections.Generic;

namespace Entity.Configs
{
    public class ProjectConfig : IEntity<string>
    {
        [BsonId]
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string Id { get; set; }
        public string ProjectId { get; set; }
        [BsonIgnoreIfDefault]
        [BsonDefaultValue(false)]
        public bool IsDefault { get; set; } = false;
        public DateTime DateTime { get; set; }
        public List<ProjectServer> ProjectServers { get; set; }
        public Dictionary<string, object> Data { get; set; }
    }
}
