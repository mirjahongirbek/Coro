using Entity;
using Entity.Projects;
using Entity.Sms;
using Entity.ViewModal.Rest;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Service.Commands;
using Service.Interfaces;
using Service.Interfaces.Message;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Commutator.Models
{
    public static class State
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
        public static Project GetPartner(this ControllerBase cBase, IProjectService _partner, IMessageService _message, SendModal model = null)
        {
            try
            {
                var pair = cBase.UserNamePassword();
                if (!pair.HasValue)
                {
                    throw new Exception();
                }
                var partner = _partner.GetFirst(m => m.Name == pair.GetValueOrDefault().Key && m.Password == pair.GetValueOrDefault().Value);
                if (partner == null)
                {
                    partner = _partner.AddUnauthorizePartner(pair);
                    RestViewModal viewModal = new RestViewModal()
                    {
                        Header = cBase.Request.Headers.ToDict()
                    };

                    _message.SendUnAuthoriseMessage(model,
                                                    partner, viewModal);
                    throw new Exception();
                }
                if (partner.IsActive)
                    return partner;
                return null;

            }
            catch (Exception ext)
            {
                Console.WriteLine(ext.Message);
                return null;
            }
        }
      
        public static KeyValuePair<string, string>? UserNamePassword(this ControllerBase cBase)
        {
            if (cBase.Request.Headers.ContainsKey("Authorization")) return null;
            var header = cBase.Request.Headers["Authorization"];
            if (header.ToString().StartsWith("Basic ", StringComparison.OrdinalIgnoreCase))
            {
                var encodedUsernamePassword = header.ToString().Split(' ', 2, StringSplitOptions.RemoveEmptyEntries)[1]?.Trim();
                var result = Encoding.UTF8.GetString(Convert.FromBase64String(encodedUsernamePassword));
                if (string.IsNullOrEmpty(result))
                {
                    return new KeyValuePair<string, string>(result.Split(':', 2)[0], result.Split(':', 2)[1]);
                }

            }
            return null;

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
