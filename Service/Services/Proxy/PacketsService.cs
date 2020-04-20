using System.Collections.Generic;
using Entity.Projects;
using Entity.Proxy;
using Entity.ViewModal.Rest;
using MongoRepositorys.MongoContext;
using MongoRepositorys.Repository;
using Service.Interfaces.Proxy;


namespace Service.Services.Proxy
{
    public class PacketsService : MongoRepository<Packets>, IPacketsService
    {
        public PacketsService(IMongoContext context) : base(context)
        {
        }

        public byte Request()
        {
            throw new System.NotImplementedException();
        }

        public void SendAuthorize(RestViewModal modal, Project project)
        {
            throw new System.NotImplementedException();
        }

        public void SendUnuthorize(RestViewModal modal, Dictionary<string, string> dict)
        {
            throw new System.NotImplementedException();
        }
    }
}
