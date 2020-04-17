using Entity.Users;
using Entity.ViewModal.UserProject;
using MongoRepositorys.MongoContext;
using MongoRepositorys.Repository;
using Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Service.Services
{
    public class UserProjectService : MongoRepository<UserProjects>, IUserProjectServise
    {
        IUserService _user;
        public UserProjectService(IMongoContext context,
              IUserService user
            ) : base(context)
        {
            _user = user;
        }

        public async Task<AddUsersProjectResponse> AddUsersProject(AddUsersProject model, UserProjects addUserId)
        {
            List<UserProjects> list = new List<UserProjects>();
            foreach (var i in model.UserIds)
            {
                var user = _user.Get(i);
                list.Add(AddProjectUser(user, addUserId));
            }
            return new AddUsersProjectResponse()
            {
                UserProjects = list
            };
        }
        public UserProjects AddProjectUser(User user, UserProjects addUser)
        {
            var project = GetFirst(m => m.UserId == user.Id && m.ProjectId == addUser.ProjectId);
            if (project != null)
            {

            }
            project = new UserProjects()
            {
                UserId = user.Id,
                ProjectId = addUser.ProjectId,
                ProjectName = addUser.ProjectName,
                UserStatus = AuthModel.Enum.UserStatus.Active,
                AddDate = DateTime.Now,
                AddUserId = addUser.UserId
            };

            Add(project);
            return project;

        }
    }
}
