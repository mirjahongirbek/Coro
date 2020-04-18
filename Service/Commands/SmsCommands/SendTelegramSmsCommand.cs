using System.Threading.Tasks;
using Entity.Projects;
using Entity.Sms;

namespace Service.Commands
{
    public class SendTelegramSmsCommand : ISmsCommand
    {
         
        public string Name => "sendtelegram";

        public async Task Run(Project partner, SendModal modal)
        {
            
        }
    }


}
