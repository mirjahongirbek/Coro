using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Entity.Projects;
using Entity.Proxy;
using Entity.ViewModal.Rest;
using MongoDB.Driver;
using MongoRepositorys.MongoContext;
using MongoRepositorys.Repository;
using RestSharp;
using SendRequest;
using Service.Interfaces.Proxy;


namespace Service.Services.Proxy
{
    public class PacketsService : MongoRepository<Packets>, IPacketsService
    {
        IRequestService _req;
        IMongoCollection<Packets> _unauthorize = null;
        public PacketsService(IMongoContext context, IRequestService req) : base(context)
        {
            _req = req;
            _unauthorize = context.Database.GetCollection<Packets>("UnAuthorizePacket");
        }

        public byte Request()
        {
            throw new System.NotImplementedException();
        }

        public async Task<IRestResponse> SendAuthorize(RestViewModal model, Project project)
        {
            var packet = Start(model);
            var service = project.GetServices(Entity.Enum.Services.Rest).FirstOrDefault(m => m.BaseUrl == model.BaseUrl());
            if (service != null)
            {
                Entity.State.ParseService(service, model);
            }
            var result = await _req.Send(model);
            packet.ProjectId = project.Id;
            SaveAuthorize(packet, result);
            return result;
        }        
        public async Task<IRestResponse> SendUnuthorize(RestViewModal model)
        {
            var packet = Start(model);
            var result = await _req.Send(model);
            SaveUnAuthorize(packet, result);
            return result;
        }
        public void SaveAuthorize(Packets packet, IRestResponse response)
        {
            packet.Response = response.RawBytes;
            packet.ResponseStatus = (int)response.StatusCode;
            packet.RestPacket.StopWatch.Stop();
            packet.Duration = packet.RestPacket.StopWatch.ElapsedMilliseconds;
            Add(packet);
        }
        public void SaveUnAuthorize(Packets packet, IRestResponse response)
        {
            packet.Response = response.RawBytes;
            packet.ResponseStatus = (int)response.StatusCode;
            packet.RestPacket.StopWatch.Stop();
            packet.Duration = packet.RestPacket.StopWatch.ElapsedMilliseconds;
            _unauthorize.InsertOne(packet);
        }
        public Packets Start(RestViewModal model)
        {
            var watch = Stopwatch.StartNew();
            model.StopWatch = Stopwatch.StartNew();
            var packet = Packets.Create(model);
            return packet;

        }
        public async Task<IRestResponse> Send(ProjectServer server, RestViewModal modal)
        {
            return await _req.Send(server, modal);


        }
    }
}
