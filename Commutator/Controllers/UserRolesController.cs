using AuthModel.Interfaces;
using AuthService.Controller;
using Entity.Users;
using Microsoft.AspNetCore.Mvc;
using Service.Interfaces;

namespace Commutator.Controllers
{
    [ApiController]
    [Route("/api/[controller]/[action]")]
    public class UserRolesController : UserRoleController<User, UserRole, Role, string>
    {
        IUserProjectServise _myProjects;
        public UserRolesController(IUserRoleRepository<User, Role, UserRole, string> userRole,
            IUserProjectServise myProjects
            ) : base(userRole)
        {
            _myProjects = myProjects;
        }

        

    }
}
