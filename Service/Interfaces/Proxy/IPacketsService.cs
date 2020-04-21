using System.Collections.Generic;
using System.Threading.Tasks;
using Entity.Projects;
using Entity.Proxy;
using Entity.ViewModal.Rest;
using RepositoryCore.Interfaces;
using RestSharp;

namespace Service.Interfaces.Proxy
{
    public interface IPacketsService : IRepositoryCore<Packets, string>
    {
        byte Request();
        Task<IRestResponse> SendAuthorize(RestViewModal modal, Project project);
        Task<IRestResponse> SendUnuthorize(RestViewModal model);
    }

}
