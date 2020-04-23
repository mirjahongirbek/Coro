using CoreResults;
using Entity.Projects;
using Entity.ViewModal.Project;
using Microsoft.AspNetCore.Mvc;
using Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Commutator.Controllers
{
    [ApiController]
    [Route("/api/[controller]/[action]")]
    public class AdminController : ControllerBase
    {
        IProjectService _project;
        public AdminController(IProjectService project)
        {
            _project = project;
        }
        [HttpPost]
        public async Task<NetResult<List<Project>>> Projects([FromBody]RestQueryModal model)
        {
            try
            {
                return _project.FindReverse(m => true).Skip(model.Offset).Take(model.Limit).ToList();
            }
            catch (Exception ext)
            {
                return ext;
            }
        }
        [HttpGet]
        public async Task<NetResult<ProjectServices>> GetProjectService(string id)
        {
            try
            {
                var project = _project.GetFirst(m => m.ProjectService.Any(n => n.Id == id));
                var service = project.ProjectService.FirstOrDefault(m => m.Id == id);
                return service;
            }
            catch (Exception ext)
            {
                return ext;
            }
        }
        [HttpGet]
        public async Task<NetResult<Project>> GetProject(string id)
        {
            try
            {
                var project = _project.Get(id);
                return project;
            }
            catch (Exception ext)
            {
                return ext;
            }
        }
    }

}
