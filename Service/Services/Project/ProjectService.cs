using Entity.Projects;
using Entity.ViewModal.Rest;
using MongoRepositorys.MongoContext;
using MongoRepositorys.Repository;
using Service.Interfaces;
using System;
using System.Collections.Generic;
using PrService = Entity.Projects.ProjectServices;


namespace Service.Services
{
    public class ProjectService : MongoRepository<Project>, IProjectService
    {
        IUserService _userService;
        public ProjectService(IMongoContext context, IUserService userService) : base(context)
        {
            _userService = userService;

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
            { Services = modal.Services, 
                UserName = pair.Key,
                Password = pair.Value, };
            service.Request = new List<ProjectServer>();
            var projectSerice = new ProjectServer() 
            { UserName = pair.Key,
                Password = pair.Value, 
                Url = modal.Url };
            service.Request.Add(projectSerice);
            Project newProject = new Project() { ProjectService = new List<PrService>() { service }, IsActive = false, DateTime = DateTime.Now, PrjectStatus = AuthModel.Enum.UserStatus.NotActivated, };
            Add(newProject); return newProject;
        }
    }
}
