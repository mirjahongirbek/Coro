using Commutator.Models;
using Microsoft.AspNetCore.Mvc;
using Service.Interfaces;
using System;

namespace Commutator.Controllers
{
    [ApiController]
    [Route("/api/[controller]/[action]")]
    public class ProjectConfigController : ControllerBase
    {
        public IProjectService _project;
        
        public ProjectConfigController(IProjectService project)
        {
            _project = project;
        }
        public void GetConfig()
        {
            try
            {
                var project = this.GetProject(_project);
               var service= project.GetService(Entity.Enum.Services.Config);
                var ip = HttpContext.Connection.RemoteIpAddress.ToString();

            }
            catch(Exception ext)
            {

            }
           
                      

        }
        

    }


}
