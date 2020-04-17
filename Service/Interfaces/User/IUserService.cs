using AuthModel.Interfaces;
using Entity.Users;

namespace Service.Interfaces
{
    public interface IUserService : IAuthRepository<User, UserRole, string>
    {

    }
    
}
