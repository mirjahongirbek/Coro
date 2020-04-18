using Entity;
using Entity.Projects;
using Entity.Sms;
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
        public static KeyValuePair<string, string> Coro(this Dictionary<string, string> dict)
        {

            var username = dict.FirstOrDefault(m => m.Key.ToLower() == "coroname").ToString();
            var pass = dict.FirstOrDefault(m => m.Key.ToLower() == "coropass");

        }
        public static Project GetProject(this ControllerBase cBase, IProjectService project)
        {
            try
            {



            }
            catch (Exception ext)
            {

            }
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
                    _message.SendUnAuthoriseMessage(model,
                                                    partner);
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
        public static KeyValuePair<string, string>? CoroUserNamePassword(this ControllerBase cBase)
        {
            var username = cBase.Request.Headers.FirstOrDefault(m => m.Key.ToLower() == "corouser").Value;
            var password = cBase.Request.Headers.FirstOrDefault(m => m.Key.ToLower() == "coropassword").Value;

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
