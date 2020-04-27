
using Entity.Telegram;
using System.Threading.Tasks;
using Telegram.Bot.Types;

namespace TelegramService.Commands
{
    public interface ITeleCommands
    {
        string Name { get; }
        void SetData<T>(T data);
        Task Run(TelegramUser tuser, Message message);
    }
}
