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
        public Task FromRequest([FromBody]RestViewModal modal)
        {

            var projectName = Request.Headers.FirstOrDefault(m => m.Key.ToLower() == "coroname").Value;
            if (string.IsNullOrEmpty(projectName))
            {
                return Task.Factory.StartNew(async () => await SendUnuthorize(_provider, modal));
            }
            return Task.Factory.StartNew(async () => await SendAuthorize(_provider, modal));
        }
        private async Task SendUnuthorize(IServiceProvider provider, RestViewModal model)
        {
            try
            {
                var ip = this.HttpContext.Connection.RemoteIpAddress.ToString();
                model.FromIp = ip;
                var packet = provider.GetService<IPacketsService>();
                var dict = Request.Headers.ToDict();
                model.Header = dict;
                var item = await packet.SendUnuthorize(model);
                this.ConvertRest(item);
            }
            catch (Exception ext)
            {
                Console.WriteLine(ext.Message);
            }
        }
        private async Task SendAuthorize(IServiceProvider provider, RestViewModal modal)
        {
            var packet = provider.GetService<IPacketsService>();
            var dict = Request.Headers.ToDict();
            var userPass = dict.Coro();
            if (userPass == null)
            {

            }
            var coro = userPass.GetValueOrDefault();
            var _project = provider.GetService<IProjectService>();
            var project = _project.GetFirst(m => m.Name == coro.Key && m.Password == coro.Value);

            var item = await packet.SendAuthorize(modal, project);
            this.ConvertRest(item);
        }

    }





}
