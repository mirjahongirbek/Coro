using AuthService;
using CoreResults;
using Entity.Projects;
using Microsoft.AspNetCore.Mvc;
using Service.Interfaces;
using System;
using System.Threading.Tasks;

namespace Commutator.Controllers
{
    [ApiController]
    [Route("/api/[controller]/[action]")]
    public class ProjectController : ControllerBase
    {
        IProjectService _project;
        public ProjectController(IProjectService project)
        {
            _project = project;
        }
        [HttpPost]
        public async Task<NetResult<Project>> AddProject([FromBody] Project model)
        {
            try
            {
             _project.AddNewProject(model, this.UserId<string>());
                return model;
            }catch(Exception ext)
            {
                return ext;
            }

        }
        
    }
    
    

    

}
