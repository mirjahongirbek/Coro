using Entity.Users;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entity.ViewModal.UserProject
{
    public class AddUsersProject
    {
        public string ProjectId { get; set; }
        public List<string> UserIds { get; set; }
    }
    public class AddUsersProjectResponse
    {
        public List<UserProjects> UserProjects { get; set; }

    }
}
