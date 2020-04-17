using Entity;
using Entity.Sms;
using System.Threading.Tasks;

namespace Service.Commands
{
    public interface IConfigCommand
    {
        string Name { get; }
        Task Run(Partner partner, SendModal modal);      
    }
}
