using Entity.Db;
using MongoRepositorys.MongoContext;
using MongoRepositorys.Repository;
using Service.Interfaces;

namespace Service.Services
{
    public class DeleteDataService : MongoRepository<DeleteData>, IDeleteDataService
    {
        public DeleteDataService(IMongoContext context) : base(context)
        {
        }
        public void DeleteData(object data, Entity.Enum.Services service)
        {

        }
    }
}
