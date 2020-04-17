using Entity;
using Entity.Sms;
using Microsoft.AspNetCore.Mvc;
using Service.Commands;
using Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Commutator.Models
{
    public static class State
    {
        public static Partner GetPartner(this ControllerBase cBase, IPartnerService _partner, IMessageService _message, SendModal model = null)
        {
            try
            {
                var pair = cBase.UserNamePassword();
                if (!pair.HasValue)
                {
                    throw new Exception();
                }
                var partner = _partner.GetFirst(m => m.UserName == pair.GetValueOrDefault().Key && m.Password == pair.GetValueOrDefault().Value);
                if (partner == null)
                {

                    partner = _partner.AddUnauthorizePartner(pair);
                    _message.SendUnAuthoriseMessage(model, partner);
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
        public static void RunConfig(this Partner partner, IEnumerable<IConfigCommand> _confList, SendModal message)
        {
            foreach (var i in partner.Configs)
            {
                var temp = _confList.FirstOrDefault(m => m.Name.ToLower() == i.CommandName.ToLower());
                temp.Run(partner, message);
            }
        }
    }
}
