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
using Service.Interfaces.Message;
using Entity.ViewModal.Rest;

namespace Commutator.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class OtpController : ControllerBase
    {
        IEnumerable<ISmsCommand> _confList;
        IProjectService _project;
        IMessageService _message;
        public OtpController(
            IEnumerable<ISmsCommand> confList,
            IProjectService project,
             IMessageService message
            )
        {
            _confList = confList;
            _project = project;
            _message = message;
        }
        [HttpGet]
        public async Task<ResponseData> SendOtp(string phoneNumber)
        {
            try
            {
                var partner = this.GetPartner(_project, _message);
                var message = SendModal.Create(partner);
                partner.RunConfig(_confList, message);
                message.Messages.Add(new Message() { Recipient = RepositoryState.ParsePhone(phoneNumber) });
                RestViewModal viewModal = new RestViewModal()
                {
                     Header= Request.Headers.ToDict()
                };
                _message.SendOtp(partner, message, viewModal);
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
                var partner = this.GetPartner(_project, _message, model);
                
                model.BeforeConfig(partner.GetService(Entity.Enum.Services.Sms));
                partner.RunConfig(_confList, model);
                RestViewModal restModal = new RestViewModal() {  Header= Request.Headers.ToDict()};
                _message.SendMessage(partner, model, restModal);
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
                var partner = this.GetPartner(_project, _message);
                RestViewModal viewModal = new RestViewModal() { Header = Request.Headers.ToDict() };
                _message.CheckOtp(partner, model, viewModal);
                return this.GetResponse();
            }
            catch (Exception ext)
            {
                return this.GetResponse(0);
            }
        }

    }

}
