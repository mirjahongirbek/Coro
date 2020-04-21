using Entity.ViewModal.Rest;
using MongoDB.Bson.Serialization.Attributes;
using RepositoryCore.Interfaces;
using System;

namespace Entity.Proxy
{
    public class Packets : IEntity<string>
    {
        public Packets()
        {

        }
        public static Packets Create(RestViewModal viewmodal)
        {
            Packets newPacket = new Packets()
            {

                FromUrl = viewmodal.FromIp,
                Date = new DateTime(),
                RestPacket = viewmodal,
            };
            return newPacket;

        }
        [BsonId]
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string Id { get; set; }
        public string ProjectId { get; set; }
        public string FromUrl { get; set; }
        public RestViewModal RestPacket { get; set; }
        public long Duration { get; set; }
        public byte[] Response { get; set; }
        public int ResponseStatus { get; set; }
        public DateTime Date { get; set; }

    }


}
