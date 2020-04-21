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
using RestSharp;

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
        private RestViewModal DefaultRest
        {
            get
            {
                RestViewModal mdl = new RestViewModal()
                {
                    Services = Entity.Enum.Services.Sms,
                    Header = Request.Headers.ToDict(),
                    Url = Entity.CoroConfig.SmsUrl,
                    Method = Entity.Enum.Method.Post

                };
                return mdl;
            }
        }
        [HttpGet]
        public async Task<ResponseData> SendOtp(string phoneNumber)
        {
            try
            {

                var partner = this.GetProject(_project, DefaultRest);
                var message = SendModal.Create(partner);
                partner.RunConfig(_confList, message);
                message.Messages.Add(new Message() { Recipient = RepositoryState.ParsePhone(phoneNumber) });
                RestViewModal viewModal = new RestViewModal()
                {
                    Header = Request.Headers.ToDict()
                };
                await _message.SendOtp(partner, message, viewModal);
                return this.GetResponse();
            }
            catch (Exception ext)
            {
                return this.GetResponse();
            }
        }

        public async Task SendMessage([FromBody] SendModal model)
        {
            try
            {
                var rests = DefaultRest;
                var project = this.GetProject(_project, rests);
                IRestResponse rest = null;
                if (!project.IsActive)
                {
                    rest = await _message.SendUnAuthoriseMessage(model, project, rests);
                    this.ConvertRest(rest);
                    return;
                }
                model.BeforeConfig(project.GetService(Entity.Enum.Services.Sms));
                project.RunConfig(_confList, model);
                rest = await _message.SendMessage(project, model, rests);                
            }
            catch (Exception ext)
            {
                
            }
        }

        public async Task<ResponseData> CheckOtp([FromBody] CheckOtpModal model)
        {
            try
            {
                var project = this.GetProject(_project, DefaultRest);
                await _message.CheckOtp(project, model, DefaultRest);
                return this.GetResponse(true);
            }
            catch (Exception ext)
            {
                return this.GetResponse(0);
            }
        }

    }

}
