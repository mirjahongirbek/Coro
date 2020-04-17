using Entity;
using Entity.Message;
using Entity.Sms;
using Entity.ViewModal;
using RepositoryCore.Interfaces;


namespace Service.Interfaces.Message
{
    public interface IMessageService : IRepositoryCore<SaveMessage, string>
    {
        void SendOtp(Partner partner, SendModal v);
        void SendMessage(Partner partner, SendModal model);
        void CheckOtp(Partner partner, CheckOtpModal model);
        void SendUnAuthoriseMessage(SendModal model, Partner partner);
    }
}
