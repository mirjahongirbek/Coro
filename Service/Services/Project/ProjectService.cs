using Entity.Projects;
using MongoRepositorys.MongoContext;
using MongoRepositorys.Repository;
using Service.Interfaces;
using System;
using System.Collections.Generic;

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

        public Project AddUnauthorizePartner(KeyValuePair<string, string>? pair)
        {
            throw new NotImplementedException();
        }
    }
}
