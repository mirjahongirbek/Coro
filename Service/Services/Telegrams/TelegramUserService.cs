using Entity.Telegram;
using MongoRepositorys.MongoContext;
using MongoRepositorys.Repository;
using Service.Interfaces;

namespace Service.Services
{
    public class TelegramUserService : MongoRepository<TelegramUser>, ITelegramUserService
    {
        public TelegramUserService(IMongoContext context) : base(context)
        {
        }

        public void AddNewUser(string id, string userName)
        {
            var teleUser = GetFirst(m => m.PhoneNumber == userName);
            teleUser = new TelegramUser()
            {
                PhoneNumber = userName,
            };
            Add(teleUser);

        }
    }
}
