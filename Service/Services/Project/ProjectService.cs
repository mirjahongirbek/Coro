using Entity.Enum;
using Entity.Projects;
using Entity.ViewModal.Rest;
using MongoRepositorys.MongoContext;
using MongoRepositorys.Repository;
using Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PrService = Entity.Projects.ProjectServices;


namespace Service.Services
{
    public class ProjectService : MongoRepository<Project>, IProjectService
    {
        IUserService _userService;
        IDeleteDataService _delete;
        public ProjectService(IMongoContext context, IUserService userService, IDeleteDataService delete) : base(context)
        {
            _userService = userService;
            _delete = delete;

        }
        public void AddNewProject(Project model, string userId)
        {
            var exist = GetFirst(m => m.Name == model.Name);
            if (exist != null)
            {
                return;
            }
            model.AddUserId = userId;
            model.DateTime = DateTime.Now;
            Add(model);
        }

        public Project AddUnauthorizePartner(KeyValuePair<string, string> pair, RestViewModal modal)
        {

            PrService service = new PrService()
            {
                Services = modal.Services,
                UserName = pair.Key,
                Password = pair.Value,
            };
            service.Request = new List<ProjectServer>();
            var projectSerice = new ProjectServer()
            {
                UserName = pair.Key,
                Password = pair.Value,
                Url = modal.Url
            };
            service.Request.Add(projectSerice);
            Project newProject = new Project() { ProjectService = new List<PrService>() { service }, IsActive = false, DateTime = DateTime.Now, PrjectStatus = AuthModel.Enum.UserStatus.NotActivated, };
            Add(newProject); return newProject;
        }
        #region  Delete Service
        public async Task DeleteService(string projectId, string serviceId, Entity.Enum.Services config)
        {
            var project = Get(projectId);
            if (project == null)
            {
                return;
            }
            switch (config)
            {
                case Entity.Enum.Services.Project: DeleteProject(project); return;
                case Entity.Enum.Services.Config:
                case Entity.Enum.Services.Rest:
                case Entity.Enum.Services.Sms: DeleteServices(project, serviceId); break;
            }
            Update(project);
            return;
        }
        public void DeleteProject(Project project)
        {
            _delete.DeleteData(project, Entity.Enum.Services.Project);
            Delete(project);
        }
        public void DeleteServices(Project project, string serviceId)
        {
            var a = project.ProjectService.FirstOrDefault(m => m.Id == serviceId);
            project.ProjectService.Remove(a);
        }
        #endregion
    }
}
