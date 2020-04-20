using Entity.ViewModal.Rest;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using System.Linq;
using Service.Interfaces.Proxy;
using Commutator.Models;
using Entity;
using Service.Interfaces;

namespace Commutator.Controllers
{
    [ApiController]
    [Route("/api/[controller]/[action]")]
    public class RestController : ControllerBase
    {
        IServiceProvider _provider;

        public RestController(IServiceProvider provider)
        {
            _provider = provider;

        }

        [HttpPost]
        public Task<string> FromRequest([FromBody]RestViewModal modal)
        {

            var projectName = Request.Headers.FirstOrDefault(m => m.Key.ToLower() == "coroname").Value;

            if (string.IsNullOrEmpty(projectName))
            {
                return Task.Factory.StartNew<string>(() => SendUnuthorize(_provider, modal));
            }
            return Task.Factory.StartNew<string>(() => SendAuthorize(_provider, modal));
        }
        private string SendUnuthorize(IServiceProvider provider, RestViewModal modal)
        {
            var packet = provider.GetService<IPacketsService>();
            var dict = Request.Headers.ToDict();
            packet.SendUnuthorize(modal, dict);
            return "";
        }
        private string SendAuthorize(IServiceProvider provider, RestViewModal modal)
        {
            var packet = provider.GetService<IPacketsService>();
            var dict = Request.Headers.ToDict();
            var userPass = dict.Coro();
            var _project = provider.GetService<IProjectService>();
            var project = _project.GetFirst(m => m.Name == userPass.Key && m.Password == userPass.Value);
            packet.SendAuthorize(modal, project);
            return "";

        }

    }





}
