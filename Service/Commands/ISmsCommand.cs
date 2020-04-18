using Entity;
using Entity.Projects;
using Entity.Sms;
using System.Threading.Tasks;

namespace Service.Commands
{
    public interface ISmsCommand
    {
        string Name { get; }
        Task Run(Project project, SendModal model);
    }
}
