using AuthService;
using CoreResults;
using Entity.Users;
using Entity.ViewModal.UserProject;
using Microsoft.AspNetCore.Mvc;
using RepositoryCore.Enums;
using Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Commutator.Controllers
{

    [ApiController]
    [Route("/api/[controller]/[action]")]
    public class UserProjectController : ControllerBase
    {
        IUserProjectServise _myProjects;
        IProjectService _project;
        public UserProjectController(IUserProjectServise myProjects, IProjectService project)
        {
            _myProjects = myProjects;
            _project = project;
        }
        [HttpGet]
        public async Task<NetResult<List<UserProjects>>> MyProjects()
        {
            return _myProjects.FindAll().ToList();
            return _myProjects.Find(m => m.UserStatus == AuthModel.Enum.UserStatus.Active && m.UserId == this.UserId<string>()).ToList();
        }
        [HttpPost]
        public async Task<NetResult<AddUsersProjectResponse>> AddUsersProject([FromBody] AddUsersProject model)
        {
           var existProject= _myProjects.GetFirst(m => m.UserId == this.UserId<string>() && model.ProjectId == m.ProjectId);
            if(existProject== null)
            {
                return StatusCore.BadRequest;
            }
            AddUsersProjectResponse result = await _myProjects.AddUsersProject(model, existProject);
            return result;
        }
        [HttpPost]
        public async Task<NetResult<AddUsersProjectResponse>> RemoveUsersProject([FromBody]AddUsersProject model)
        {
            try
            {



            }catch(Exception ext)
            {

            }
            return null;
        }
    }

}
