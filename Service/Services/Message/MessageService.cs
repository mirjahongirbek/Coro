

using Entity;
using Entity.Message;
using Entity.Sms;
using Entity.ViewModal;
using MongoRepositorys.MongoContext;
using MongoRepositorys.Repository;
using Service.Interfaces;
using System.Linq;

namespace Service.Services
{
    public class MessageService : MongoRepository<SaveMessage>, IMessageService
    {
        public MessageService(IMongoContext context) : base(context)
        {

        }
        public void CheckOtp(Partner partner, CheckOtpModal model)
        {

            throw new System.NotImplementedException();
        }
        public void SendMessage(Partner partner, SendModal model)
        {
            throw new System.NotImplementedException();
        }
        public void SendOtp(Partner partner, SendModal modal)
        {
            RepositoryCore.CoreState.RepositoryState.RandomInt();

        }
        public void SaveMessage(Partner partner,SendModal model)
        {
           var mst= partner.Configs.FirstOrDefault(m => m.CommandName=="savemessage");
            if(mst== null) { return; }
            SaveMessage modal = new SaveMessage();
            modal.IsSend = model.IsSended;
            modal.Otp = model.Otp;
            modal.Token = model.Token;
            Add(modal);         

        }

        public void SendUnAuthoriseMessage(SendModal model, Partner partner)
        {
            throw new System.NotImplementedException();
        }
    }
}
