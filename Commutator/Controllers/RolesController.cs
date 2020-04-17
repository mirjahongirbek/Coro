using AuthModel.Interfaces;
using AuthService.Controller;
using Entity.Users;

namespace Commutator.Controllers
{
    public class RolesController : RoleManagerController<Role, string>
    {
        public RolesController(IRoleRepository<Role, string> role) : base(role)
        {
        }
    }

}
