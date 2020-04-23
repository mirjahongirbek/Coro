

using System.Threading.Tasks;
using Entity.Configs;
using Entity.Projects;
using RepositoryCore.Interfaces;

namespace Service.Interfaces.Config
{
    public interface IConfigService : IRepositoryCore<ProjectConfig, string>
    {
        Task AddNewConfig(Project project, ProjectConfig config);
        Task DeleteConfig(ProjectConfig config);
    }
}
