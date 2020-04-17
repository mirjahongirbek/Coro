using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Service.Commands;
using Entity.Sms;
using Entity.ViewModal;
using Service.Interfaces;
using RepositoryCore.CoreState;
using Commutator.Models;
using System;
using RepositoryCore.Models;
using CoreResults;
using System.Threading.Tasks;

namespace Commutator.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class OtpController : ControllerBase
    {
        IEnumerable<IConfigCommand> _confList;
        IPartnerService _partner;
        IMessageService _message;
        public OtpController(
            IEnumerable<IConfigCommand> confList,
            IPartnerService partner,
             IMessageService message
            )
        {
            _confList = confList;
            _partner = partner;
            _message = message;
        }
        [HttpGet]
        public async Task<ResponseData> SendOtp(string phoneNumber)
        {
            try
            {
                var partner = this.GetPartner(_partner, _message);
                var message = SendModal.Create(partner);
                partner.RunConfig(_confList, message);
                message.Messages.Add(new Message() { Recipient = RepositoryState.ParsePhone(phoneNumber) });
                _message.SendOtp(partner, message);
                return this.GetResponse();
            }
            catch (Exception ext)
            {
                return this.GetResponse();
            }
        }

        public async Task<ResponseData> SendMessage([FromBody] SendModal model)
        {
            try
            {
                var partner = this.GetPartner(_partner, _message, model);
                model.BeforeConfig(partner);
                partner.RunConfig(_confList, model);
                _message.SendMessage(partner, model);
                return this.GetResponse();
            }
            catch (Exception ext)
            {
                return this.GetResponse();

            }
        }

        public async Task<ResponseData> CheckOtp([FromBody] CheckOtpModal model)
        {
            try
            {
                var partner = this.GetPartner(_partner, _message);
                _message.CheckOtp(partner, model);
                return this.GetResponse();
            }
            catch (Exception ext)
            {
                return this.GetResponse(0);
            }
        }

    }

}
