using MongoDB.Driver;
using MongoRepositorys.MongoContext;

namespace Entity.Db
{
    public class MongoContext:IMongoContext
    {
        public MongoContext(string connectionString)
        {
            MongoClient client = new MongoClient(connectionString);
            Database = client.GetDatabase("commutator");
        }

        public IMongoDatabase Database { get; }
    }
}
