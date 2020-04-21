using AuthService;
using CoreResults;
using Entity.Projects;
using Entity.ViewModal.Project;
using Microsoft.AspNetCore.Mvc;
using Service.Interfaces;
using Service.Interfaces.Config;
using Service.Interfaces.Proxy;
using System;
using System.Threading.Tasks;

namespace Commutator.Controllers
{
    [ApiController]
    [Route("/api/[controller]/[action]")]
    public class ProjectController : ControllerBase
    {
        IProjectService _project;
        IPacketsService _packet;
        IConfigService _config;

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
            }
            catch (Exception ext)
            {
                return ext;
            }
        }


        [HttpPost]
        public async Task RestQuery([FromBody]RestQueryModal model)
        {
            try
            {
               var project= _project.Get(model.ProjectId);
                

            }catch(Exception ext)
            {

            }

        }
        [HttpPost]
        public async Task OtpQuery([FromBody]RestQueryModal model)
        {
            try
            {

            }
            catch (Exception ext)
            {

            }
        }
        [HttpPost]
        public async Task ConfiQuery([FromBody] RestQueryModal model)
        {
            try
            {

            }
            catch (Exception ext)
            {

            }

        }

    }






}
