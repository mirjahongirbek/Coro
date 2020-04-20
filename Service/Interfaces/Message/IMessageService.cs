using Entity;
using Entity.Message;
using Entity.Projects;
using Entity.Sms;
using Entity.ViewModal;
using Entity.ViewModal.Rest;
using RepositoryCore.Interfaces;


namespace Service.Interfaces.Message
{
    public interface IMessageService : IRepositoryCore<SaveMessage, string>
    {
        void SendOtp(Project partner, SendModal v, RestViewModal rest);
        void SendMessage(Project partner, SendModal model, RestViewModal rest);
        void CheckOtp(Project partner, CheckOtpModal model, RestViewModal rest);
        void SendUnAuthoriseMessage(SendModal model, Project partner, RestViewModal rest);
    }
}
