using Entity.ViewModal.Rest;
using MongoDB.Bson.Serialization.Attributes;
using RepositoryCore.Interfaces;

namespace Entity.Proxy
{
    public class Packets : IEntity<string>
    {
        [BsonId]
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string Id { get; set; }
        public string ProjectId { get; set; }
        public string FromUrl { get; set; }
        public RestViewModal RestPacket { get; set; }
        public long Duration { get; set; }
        public string Response { get; set; }
    }

}
