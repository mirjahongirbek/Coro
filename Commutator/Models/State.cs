
using Entity;
using Entity.Projects;
using Entity.Sms;
using Entity.ViewModal.Rest;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RestSharp;
using Service.Commands;
using Service.Interfaces;
using Service.Interfaces.Message;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Commutator.Models
{
    public static partial class State
    {
        public static Project GetProjectByService(IProjectService projectService,
            Entity.Enum.Services service, KeyValuePair<string, string> pair)
        {
            var project = projectService.GetFirst(m => m.ProjectService.Any(n => n.UserName == pair.Key && n.Password == pair.Value && n.Services == service));
            return project;
        }
        public static Project GetProject(this ControllerBase cBase, IProjectService project)
        {
            try
            {
                var userName = cBase.Request.Headers.FirstOrDefault(m => m.Key.ToLower() == CoroConfig.CoroUser).Value;
                var password = cBase.Request.Headers.FirstOrDefault(m => m.Key.ToLower() == CoroConfig.CoroPassword).Value;
                var prjkt = project.GetFirst(m => m.Name == userName && m.Password == password);
                return prjkt;
            }
            catch (Exception ext)
            {

            }
            return null;
        }
        public static Project GetProjectByCoro(IProjectService projectService, KeyValuePair<string, string> pair)
        {
            return projectService.GetFirst(m => m.Name == pair.Key && m.Password == pair.Value);

        }

    }
    public static partial class State
    {
        public static Dictionary<string, string> ToDict(this IHeaderDictionary heders)
        {
            Dictionary<string, string> dicts = new Dictionary<string, string>();
            foreach (var i in heders)
            {
                dicts.Add(i.Key, i.Value.ToString());
            }
            return dicts;

        }

        public static void ConvertRest(this ControllerBase cBase, IRestResponse rest)
        {

            Console.WriteLine(rest.RawBytes.Count());
            var response = cBase.HttpContext.Response;
            response.ContentType = rest.ContentType;
            foreach (var i in rest.Headers)
            {
                Console.WriteLine(i.Name + " --> " + i.Value.ToString());
                Console.WriteLine(i.Value.ToString());
                try
                {
                    //response.Headers.Add(i.Name, i.Value.ToString());
                }
                catch (Exception ext)
                {

                }
            }
            response.StatusCode = (int)rest.StatusCode;
            response.Body.WriteAsync(rest.RawBytes, 0, rest.RawBytes.Count()).Wait();
            response.ContentLength = rest.RawBytes.Count();
        }
        public static Project GetProject(this ControllerBase cBase,
            IProjectService project,
             RestViewModal model
            )
        {
            var dicts = cBase.Request.Headers.ToDict();
            var coro = Entity.State.Coro(dicts);
            if (coro.HasValue)
            {
                return GetProjectByCoro(project, coro.GetValueOrDefault());
            }
            var userPass = dicts.UserNamePassword();
            if (!userPass.HasValue)
            {

            }
            var pass = userPass.GetValueOrDefault();
            model.UserName = pass.Key;
            model.Password = pass.Value;
            var selectProject = project.GetFirst(m => m.ProjectService.Any(n => n.Services == model.Services && n.UserName == pass.Key && n.Password == pass.Value));
            if (selectProject == null)
            {
                selectProject = project.AddUnauthorizePartner(pass, model);
            }
            return selectProject;
        }


        public static void RunConfig(this Project project, IEnumerable<ISmsCommand> _confList, SendModal message)
        {
            var service = project.GetService(Entity.Enum.Services.Sms);

            foreach (var i in service.Configs)
            {
                var temp = _confList.FirstOrDefault(m => m.Name.ToLower() == i.CommandName.ToLower());
                temp.Run(project, message);
            }
        }
    }
}
/*
   public static Project GetPartner(this ControllerBase cBase, IProjectService _partner,
            IMessageService _message, SendModal model = null)
        {
            try
            {
                RestViewModal mdl = new RestViewModal()
                {
                    Services = Entity.Enum.Services.Sms,
                    Header = cBase.Request.Headers.ToDict(),
                    Url = Entity.CoroConfig.SmsUrl,
                    Method = Entity.Enum.Method.Post

                };
                var coro = mdl.Header.Coro();
                Project project = null;
                if (coro.HasValue)
                {
                    project = GetProjectByCoro(_partner, coro.Value);
                }
                var pair = mdl.Header.UserNamePassword();
                if (!pair.HasValue)
                {
                    throw new Exception();
                }
                project = GetProjectByService(_partner, Entity.Enum.Services.Sms, pair.GetValueOrDefault());
                if (project == null)
                {
                    project = _partner.AddUnauthorizePartner(pair.GetValueOrDefault(), mdl);

                }
                if (!project.IsActive)
                {
                    var result = _message.SendUnAuthoriseMessage(model, project, mdl).Result;
                    cBase.ConvertRest(result);
                    return null;
                }

                if (project.IsActive)
                    return project;
                return null;

            }
            catch (Exception ext)
            {
                Console.WriteLine(ext.Message);
                return null;
            }
        }

     
     */
