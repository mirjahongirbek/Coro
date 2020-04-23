using System.Linq;
using System.Threading.Tasks;
using Entity.Configs;
using Entity.Projects;
using MongoDB.Bson;
using MongoRepositorys.MongoContext;
using MongoRepositorys.Repository;
using Service.Interfaces;
using Service.Interfaces.Config;


namespace Service.Services.Config
{
    public class ConfigService : MongoRepository<ProjectConfig>, IConfigService
    {
        IDeleteDataService _delete;
        public ConfigService(IMongoContext context, IDeleteDataService delete) : base(context)
        {
            _delete = delete;
        }

        public async Task AddNewConfig(Project project, ProjectConfig config)
        {

            config.Id = ObjectId.GenerateNewId().ToString();
            if (project.ProjectService == null)
            {
                project.ProjectService = new System.Collections.Generic.List<ProjectServices>();
            }
            if (config.ProjectServers != null)
            {
                var item = config.ProjectServers.Where(m => string.IsNullOrEmpty(m.ServerIp)).ToList();
                if (item == null || item.Count() > 0)
                {
                    foreach (var i in item)
                        config.ProjectServers.Remove(i);
                }
            }
            project.ProjectService.Add(new ProjectServices() { Services = Entity.Enum.Services.Config, Id = config.Id, IsActive = config.IsDefault });
            Add(config);

        }

        public async Task DeleteConfig(ProjectConfig config)
        {
            _delete.DeleteData(config, Entity.Enum.Services.Config);
            Delete(config);
        }
    }
}
