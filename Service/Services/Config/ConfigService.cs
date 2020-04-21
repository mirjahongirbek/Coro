using Entity.Configs;
using MongoRepositorys.MongoContext;
using MongoRepositorys.Repository;
using Service.Interfaces.Config;


namespace Service.Services.Config
{
    public class ConfigService : MongoRepository<ProjectConfig>, IConfigService
    {
        public ConfigService(IMongoContext context) : base(context)
        {
        }

    }
}
