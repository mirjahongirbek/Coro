using Entity.Telegram;
using RepositoryCore.Interfaces;

namespace Service.Interfaces
{
    public interface ITelegramUserService: IRepositoryCore<TelegramUser, string>
    {
        void AddNewUser(string id, string userName);
    }
    
}
