using System.Collections.Generic;
using Entity.Projects;
using Entity.Proxy;
using Entity.ViewModal.Rest;
using RepositoryCore.Interfaces;


namespace Service.Interfaces.Proxy
{
    public interface IPacketsService : IRepositoryCore<Packets, string>
    {
        byte Request();
        void SendAuthorize(RestViewModal modal, Project project);
        void SendUnuthorize(RestViewModal modal, Dictionary<string, string> dict);
    }

}
