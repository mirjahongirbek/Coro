using Entity.Message;
using Entity.Projects;
using Entity.Sms;
using Entity.ViewModal;
using MongoRepositorys.MongoContext;
using MongoRepositorys.Repository;
using PService = Entity.Projects.ProjectServices;
using Service.Interfaces.Message;
using System;
using System.Linq;
using SendRequest;
using Entity.ViewModal.Rest;
using Newtonsoft.Json;
using System.Collections.Generic;
using RestSharp;
using System.Threading.Tasks;
using MongoDB.Driver;
using SaveM = Entity.Message.SaveMessage;
using Entity.ViewModal.Message;

namespace Service.Services
{
    //Parse
    public partial class MessageService
    {
        private void Parse(SaveM model, IRestResponse response, Project partner = null)
        {
            model.StopWatch.Stop();
            model.Duration = model.StopWatch.ElapsedMilliseconds;
            

        }
        private void SaveOtp(SaveM model)
        {
            _sendOtp.InsertOne(model);
        }
        public void ParseService(ProjectServices pService, SendModal model)
        {

        }
    }
    //Otp Configuration
    public partial class MessageService
    {

        public async Task<IRestResponse> SendOtp(Project partner, SendModal model, RestViewModal rest)
        {

            var isSend = GetFirst(m => m.PhoneNumber == model.Messages[0].Recipient
             && m.CreateDate >= DateTime.Now.AddMinutes(-3) &&
             m.ProjectId == partner.Id);
            if (isSend != null)
            {
                return null;
            }
            var save = SaveM.Create(model);
            var otp = RepositoryCore.CoreState.RepositoryState.RandomInt();
            model.Messages[0].Sms.Content.Text = "Activate Code: " + otp;
            save.Otp = otp;
            save.PhoneNumber = model.Messages[0].Recipient;
            save.Token = RepositoryCore.CoreState.RepositoryState.GenerateRandomString(12);
            var item = JsonConvert.SerializeObject(model);
            rest.Data = JsonConvert.DeserializeObject<Dictionary<string, object>>(item);
            var service = partner.GetService(Entity.Enum.Services.Sms);
            if (service == null)
            {
                service = GetDefaultService();
            }
            var result = await _request.Send(service.Request.FirstOrDefault(), rest);
            save.ProjectId = partner.Id;
            Parse(save, result, partner);
            Add(save);
            return result;
        }

    }
    public partial class MessageService : MongoRepository<SaveMessage>, IMessageService
    {
        IRequestService _request;
        IMongoCollection<SaveMessage> _sendOtp;
        public MessageService(IMongoContext context, IRequestService request) : base(context)
        {
            _request = request;
            _sendOtp = context.Database.GetCollection<SaveMessage>("tempOtp");
        }
        public async Task<CheckOtpModels> CheckOtp(Project partner, CheckOtpModal model, RestViewModal rest)
        {
            var item = GetFirst(m => m.ProjectId == partner.Id && m.Otp == model.Otp && m.CreateDate>=DateTime.Now.AddMinutes(-4));
            CheckOtpModels result = new CheckOtpModels();
            if (item != null)
            {
               result.PhoneNumber=  item.SendModal.Messages[0].Recipient;
                result.IsCheck = true;
            }
            else
            {
                result.IsCheck = false;
            }
            return result;
        }
        public async Task<IRestResponse> SendMessage(Project project, SendModal model, RestViewModal rest)
        {
            var message = SaveMessage.Create(model);
            var service = project.GetService(Entity.Enum.Services.Sms);
            ParseService(service, model);
            if (model.SendOtp)
            {
                return await SendOtp(project, model, rest);
            }
            var result = await Send(service.ProjectServers.FirstOrDefault(), model, rest);
            return result;
        }

        public PService GetDefaultService()
        {
            PService service = new PService()
            {

            };
            ProjectServer server = new ProjectServer() { Url = Entity.CoroConfig.SmsUrl };
            service.Request.Add(server);
            return service;
        }


        public async Task<IRestResponse> SendUnAuthoriseMessage(SendModal model, Project partner, RestViewModal rest)
        {
            var service = partner.GetService(Entity.Enum.Services.Sms);
            if (service == null)
            {
                service = GetDefaultService();
            }
            if (model.SendOtp)
            {
                return await SendOtp(partner, model, rest);
            }
            var result = await Send(service.Request.FirstOrDefault(), model, rest);
            return result;

        }
        async Task<IRestResponse> Send(ProjectServer server, SendModal model, RestViewModal rest)
        {
            rest.Data = JsonConvert.DeserializeObject<Dictionary<string, object>>(JsonConvert.SerializeObject(model));
            return await _request.Send(server, rest);
        }
    }
}
