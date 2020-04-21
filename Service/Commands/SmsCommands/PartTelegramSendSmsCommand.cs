using System.Threading.Tasks;
using Entity.Projects;
using Entity.Sms;

namespace Service.Commands
{
    public class PartTelegramSendSmsCommand : ISmsCommand
    {
        public string Name { get; }
        public bool IsRun { get; set; }

        public async Task Run(Project partner, SendModal modal)
        {
            throw new System.NotImplementedException();
        }
    }


}
