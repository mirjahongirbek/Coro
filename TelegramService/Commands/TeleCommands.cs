
using Entity.Telegram;
using System.Threading.Tasks;
using Telegram.Bot.Types;

namespace TelegramService.Commands
{
    public interface ITeleCommands
    {
        string Name { get;  }
        Task Run(TelegramUser tuser, Message message);
    }
}
