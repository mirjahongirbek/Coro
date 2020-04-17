
using System.Linq;
using System.Threading.Tasks;
using Entity;
using Entity.Sms;

namespace Service.Commands
{
    public class ChangeUserNameConfigCommand : IConfigCommand
    {
        public string Name => "changeusername";

        public async Task Run(Partner partner, SendModal modal)
        {
            var config = partner.Configs.FirstOrDefault(m => m.CommandName.ToLower() == Name.ToLower());
            if (config == null)
            {
                return;
            }
            modal.UserName = config.Key;
            modal.Password = config.Value;
        }
        
    }
    public class SendTelegramConfigCommand : IConfigCommand
    {
         
        public string Name => "sendtelegram";

        public async Task Run(Partner partner, SendModal modal)
        {
            
        }
    }
    public class PartTelegramSendConfigCommand : IConfigCommand
    {
        public string Name { get; }

        public async Task Run(Partner partner, SendModal modal)
        {
            throw new System.NotImplementedException();
        }
    }
    public class SaveSmsConfigCommand : IConfigCommand
    {
        public string Name { get; }

        public async Task Run(Partner partner, SendModal modal)
        {
            throw new System.NotImplementedException();
        }
    }


}
