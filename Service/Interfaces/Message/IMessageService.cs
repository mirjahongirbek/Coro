using Entity;
using Entity.Message;
using Entity.Projects;
using Entity.Sms;
using Entity.ViewModal;
using Entity.ViewModal.Message;
using Entity.ViewModal.Project;
using Entity.ViewModal.Rest;
using RepositoryCore.Interfaces;
using RestSharp;
using System.Threading.Tasks;

namespace Service.Interfaces.Message
{
    public interface IMessageService : IRepositoryCore<SaveMessage, string>
    {
        Task<SendOtpModel> SendOtp(Project partner, SendModal v, RestViewModal rest);
        Task<IRestResponse> SendMessage(Project partner, SendModal model, RestViewModal rest);
        Task<CheckOtpModels> CheckOtp(Project partner, CheckOtpModal model, RestViewModal rest);
        Task<IRestResponse> SendUnAuthoriseMessage(SendModal model, Project partner, RestViewModal rest);
        Task<RestQueryResponse<SaveMessage>> GetRest(RestQueryModal model);
    }
}
