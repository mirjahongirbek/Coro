using Entity.Projects;
using Entity.Sms;
using System.Threading.Tasks;

namespace Service.Commands
{
    public interface ISmsCommand
    {
        string Name { get; }
        bool IsRun { get; set; }
        Task Run(Project project, SendModal model);
    }
    
}
