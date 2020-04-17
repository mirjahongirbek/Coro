using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Entity.Projects
{
    public class ProjectServer
    {
        public ProjectServer()
        {
            Id = ObjectId.GenerateNewId().ToString();
        }
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string ServerIp { get; set; }
        public string Port { get; set;}

    }
    
}
