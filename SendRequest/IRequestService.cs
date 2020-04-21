using Entity;
using Entity.Projects;
using Entity.Sms;
using Entity.ViewModal.Rest;
using RestSharp;
using System.Threading.Tasks;

namespace SendRequest
{
    public interface IRequestService
    {
         Task<IRestResponse> Send(string url,   RestViewModal modal= null);
        Task<IRestResponse> Send(RestViewModal model);
         Task<IRestResponse> Send(Config config, RestViewModal model);
         Task<IRestResponse> Send(ProjectServer server, RestViewModal modal);
        Task<IRestResponse> Send(ProjectServer server, RestViewModal model, SendModal sms);
    }
}
