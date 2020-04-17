using MongoAuthService.Models;
using System.Collections.Generic;

namespace Entity.Users
{
    public class User : MongoUser
    {
        public List<UserProjects> UserProjects { get; set; }
    }
}
    
