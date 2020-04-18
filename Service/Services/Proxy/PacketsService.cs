using Entity.Proxy;
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

    }
}
