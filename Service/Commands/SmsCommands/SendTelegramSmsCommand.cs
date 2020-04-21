using System.Threading.Tasks;
using Entity.Projects;
using Entity.Sms;

namespace Service.Commands
{
    public class SendTelegramSmsCommand : ISmsCommand
    {
         
        public string Name => "sendtelegram";

        public bool IsRun { get; set; }

        public async Task Run(Project partner, SendModal modal)
        {
            
        }
    }


}
