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

namespace Service.Services
{
    public class MessageService : MongoRepository<SaveMessage>, IMessageService
    {
        IRequestService _request;
        public MessageService(IMongoContext context, IRequestService request) : base(context)
        {
            _request = request;
        }
        public void CheckOtp(Project partner, CheckOtpModal model, RestViewModal rest)
        {

            throw new System.NotImplementedException();
        }
        public void SendMessage(Project partner, SendModal model, RestViewModal rest)
        {
            throw new System.NotImplementedException();
        }
        public void SendOtp(Project partner, SendModal model, RestViewModal rest)
        {
            var isSend = GetFirst(m => m.PhoneNumber == model.Messages[0].Recipient
             && m.CreateDate == DateTime.Now.AddMinutes(-3) &&
             m.ProjectId == partner.Id);
            if (isSend != null)
            {

            }
            var otp = RepositoryCore.CoreState.RepositoryState.RandomInt();

            var service = partner.GetService(Entity.Enum.Services.Sms);

            if (service == null)
            {
                service = GetDefaultService();
            }
            
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

        public void SaveMessage(Project project, SendModal model, RestViewModal rest)
        {
            var service = project.GetService(Entity.Enum.Services.Sms);

            var mst = service.Configs.FirstOrDefault(m => m.CommandName == "savemessage");
            if (mst == null) { return; }
            SaveMessage modal = new SaveMessage();
            modal.IsSend = model.IsSended;
            modal.Otp = model.Otp;

            modal.Token = model.Token;
            Add(modal);

        }

        public void SendUnAuthoriseMessage(SendModal model, Project partner, RestViewModal rest)
        {
            throw new System.NotImplementedException();
        }
    }
}
