using System.Threading.Tasks;
using Entity.Projects;
using Entity.Sms;

namespace Service.Commands
{
    public class SaveSmsCommand : ISmsCommand
    {
        public string Name { get; }
        public bool IsRun { get; set; }

        public async Task Run(Project partner, SendModal model)
        {
            throw new System.NotImplementedException();
        }
    }


}
