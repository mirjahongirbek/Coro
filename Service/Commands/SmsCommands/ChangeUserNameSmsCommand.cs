
using System.Linq;
using System.Threading.Tasks;
using Entity;
using Entity.Projects;
using Entity.Sms;

namespace Service.Commands
{
    public class ChangeUserNameSmsCommand : ISmsCommand
    {
        public string Name => "changeusername";

        public bool IsRun { get; set; }

        public async Task Run(Project project, SendModal modal)
        {
           var service= project.GetService(Entity.Enum.Services.Sms);
            var config = service.Configs.FirstOrDefault(m => m.CommandName.ToLower() == Name.ToLower());
            if (config == null)
            {
                return;
            }
            modal.UserName = config.Key;
            modal.Password = config.Value;
        }
        
    }


}
