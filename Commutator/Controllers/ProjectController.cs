using AuthService;
using CoreResults;
using Entity.Configs;
using Entity.Message;
using Entity.Projects;
using Entity.ViewModal;
using Entity.ViewModal.Project;
using Microsoft.AspNetCore.Mvc;
using Service.Interfaces;
using Service.Interfaces.Config;
using Service.Interfaces.Message;
using Service.Interfaces.Proxy;
using System;
using System.Collections.Generic;
using System.Linq;
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
        IMessageService _message;

        public ProjectController(IProjectService project, IPacketsService packet,
        IConfigService config,
        IMessageService message

            )
        {
            _project = project;
            _config = config;
            _message =
                message;
            _packet = packet;
        }
        #region  Project 
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
        #endregion
        #region Rest Query
        [HttpPost]
        public async Task<NetResult<RestQueryResponse<SaveMessage>>> RestQuery([FromBody]RestQueryModal model)
        {
            try
            {
                //var project= _project.Get(model.ProjectId);
                RestQueryResponse<SaveMessage> result = await _message.GetRest(model);
                return result;
            }
            catch (Exception ext)
            {
                return ext
                    ;
            }

        }
        #endregion
        #region  Otp Query
        [HttpPost]
        public async Task<NetResult<RestQueryResponse<SaveMessage>>> OtpQuery([FromBody]RestQueryModal model)
        {
            try
            {
                //var project= _project.Get(model.ProjectId);
                RestQueryResponse<SaveMessage> result = await _message.GetRest(model);
                return result;
            }
            catch (Exception ext)
            {
                return ext
                    ;
            }
        }
        #endregion
        #region Config
        [HttpGet]
        public async Task<NetResult<List<ProjectConfig>>> ProjectConfigs(string id)
        {
            try
            {
                return _config.Find(m => m.ProjectId == id).ToList();
            }
            catch (Exception ext)
            {
                return ext;
            }
        }
        [HttpPost]
        public async Task<NetResult<ProjectConfig>> AddConfig([FromBody] ProjectConfig config)
        {
            try
            {
                Project project = null;

                if (!string.IsNullOrEmpty(config.ProjectId))
                {
                    project = _project.Get(config.ProjectId);
                }
                if (project == null)
                {
                }
                config.DateTime = DateTime.Now;

                if (config.ProjectServers == null && config.ProjectServers.Count() == 0) { config.IsDefault = true; }
                await _config.AddNewConfig(project, config);
                _project.Update(project);
                return config;
            }
            catch (Exception ext)
            {
                return ext;
            }
        }
        [HttpPut]
        public async Task<NetResult<CoroResult>> UpdateConfig([FromBody]ProjectConfig config)
        {
            try
            {
                _config.Update(config);
                return new CoroResult() { Success = true };
            }
            catch (Exception ext)
            {
                return ext;
            }
        }
        [HttpDelete]
        public async Task<NetResult<CoroResult>> DeleteConfig(string id)
        {
            try
            {
                var config = _config.Get(id);
                if (config == null)
                {
                    return null;
                }
                await _project.DeleteService(config.ProjectId, config.Id, Entity.Enum.Services.Config);
                await _config.DeleteConfig(config);
                return new CoroResult() { Success = true };
            }
            catch (Exception ext)
            {
                return ext;
            }
        }
        [HttpPost]
        public async Task<NetResult<List<ProjectConfig>>> ConfiQuery([FromBody] RestQueryModal model)
        {
            try
            {
                return _config.Find(m => m.ProjectId == model.ProjectId).ToList();
            }
            catch (Exception ext)
            {
                return ext;
            }

        }
        #endregion
    }






}
