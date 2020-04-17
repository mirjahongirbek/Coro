using System.Threading.Tasks;
using Entity.Users;
using Entity.ViewModal.UserProject;
using RepositoryCore.Interfaces;


namespace Service.Interfaces
{
    public interface IUserProjectServise : IRepositoryCore<UserProjects, string>
    {
        Task<AddUsersProjectResponse> AddUsersProject(AddUsersProject model, UserProjects v);
    }
}
