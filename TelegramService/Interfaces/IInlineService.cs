
using Entity.Telegram;
using RepositoryCore.Interfaces;

namespace TelegramService.Interfaces
{
    public interface IInlineService:IRepositoryCore<InlineButton, string>
    {
        InlineButton GetInline(string text);
    }
}
