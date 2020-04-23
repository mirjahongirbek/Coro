
using System.Collections.Generic;
using System.Threading.Tasks;
using Entity.Enum;
using Entity.Projects;
using Entity.ViewModal.Rest;
using RepositoryCore.Interfaces;

namespace Service.Interfaces
{
    public interface IProjectService : IRepositoryCore<Project, string>
    {
        void AddNewProject(Project model, string userId);
        Project AddUnauthorizePartner(KeyValuePair<string, string> pair, RestViewModal model);
        Task DeleteService(string projectId ,string serviceId, Entity.Enum.Services config);
    }
}
