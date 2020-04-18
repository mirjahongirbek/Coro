using Entity;
using Entity.Message;
using Entity.Projects;
using Entity.Sms;
using Entity.ViewModal;
using RepositoryCore.Interfaces;


namespace Service.Interfaces.Message
{
    public interface IMessageService : IRepositoryCore<SaveMessage, string>
    {
        void SendOtp(Project partner, SendModal v);
        void SendMessage(Project partner, SendModal model);
        void CheckOtp(Project partner, CheckOtpModal model);
        void SendUnAuthoriseMessage(SendModal model, Project partner);
    }
}
