using Entity.Users;
using RepositoryCore.Interfaces;
using Service.Interfaces;

namespace Service.Services
{
    public class UserService : MongoAuthService.Services.MongoUserService<User, Role, UserRole>, IUserService
    {
        public UserService(IRepositoryCore<User, string> repo) : base(repo)
        {
        }
    }
}
