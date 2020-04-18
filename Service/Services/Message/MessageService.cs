
using Entity.Message;
using Entity.Projects;
using Entity.Sms;
using Entity.ViewModal;
using MongoRepositorys.MongoContext;
using MongoRepositorys.Repository;

using Service.Interfaces.Message;
using System.Linq;

namespace Service.Services
{
    public class MessageService : MongoRepository<SaveMessage>, IMessageService
    {
        public MessageService(IMongoContext context) : base(context)
        {

        }
        public void CheckOtp(Project partner, CheckOtpModal model)
        {

            throw new System.NotImplementedException();
        }
        public void SendMessage(Project partner, SendModal model)
        {
            throw new System.NotImplementedException();
        }
        public void SendOtp(Project partner, SendModal modal)
        {
            RepositoryCore.CoreState.RepositoryState.RandomInt();

        }
        public void SaveMessage(Project project,SendModal model)
        {
           var service= project.GetService(Entity.Enum.Services.Sms);

           var mst= service.Configs.FirstOrDefault(m => m.CommandName=="savemessage");
            if(mst== null) { return; }
            SaveMessage modal = new SaveMessage();
            modal.IsSend = model.IsSended;
            modal.Otp = model.Otp;
            
            modal.Token = model.Token;
            Add(modal);         

        }

        public void SendUnAuthoriseMessage(SendModal model, Project partner)
        {
            throw new System.NotImplementedException();
        }
    }
}
